using Eve.TapToClick.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Eve.TapToClick.Utilities
{
    public class TouchpadWatcher
    {
        public delegate void TouchpadEventHandler(object sender, TouchpadEventArgs e);

        public event TouchpadEventHandler ContactStart;
        public event TouchpadEventHandler ContactUpdate;
        public event TouchpadEventHandler ContactEnd;

        public uint MinimumDetectionPressure { get; set; } = 1;

        private bool[] activeContacts;
        private Dictionary<IntPtr, byte[]> preparsedDataCache;

        public TouchpadWatcher()
        {
            activeContacts = new bool[Constants.MaxContacts];
            preparsedDataCache = new Dictionary<IntPtr, byte[]>();
        }

        protected virtual void OnContactStart(TouchpadEventArgs e)
        {
            TouchpadEventHandler handler = ContactStart;
            handler?.Invoke(this, e);
        }

        protected virtual void OnContactUpdate(TouchpadEventArgs e)
        {
            TouchpadEventHandler handler = ContactUpdate;
            handler?.Invoke(this, e);
        }

        protected virtual void OnContactEnd(TouchpadEventArgs e)
        {
            TouchpadEventHandler handler = ContactEnd;
            handler?.Invoke(this, e);
        }

        public void HandleInputMessage(ref Message message)
        {
            // Read raw input data
            RawInput rawInput = User32.GetRawInputData(message.LParam, RawInputCommand.Input);

            byte[] preparsedData;
            if (!preparsedDataCache.TryGetValue(rawInput.Header.Device, out preparsedData))
            {
                // Get preparsed data, which is used by hid.dll functions
                preparsedData = User32.GetRawInputDeviceInfo(rawInput.Header.Device, DeviceInfoType.RIDI_PREPARSEDDATA);
            }

            foreach (byte[] hidReport in rawInput.HidReports)
            {
                HandleHidReport(hidReport, preparsedData);
            }
        }

        private void HandleHidReport(byte[] hidReport, byte[] preparsedData)
        {
            // Check each of the possible contacts
            for (int i = 0; i < Constants.MaxContacts; i++)
            {
                // Are there any active usages on the contact's link collection?
                ushort[] contactUsages =
                    Hid.HidP_GetUsages(HidPReportType.HidP_Input, Constants.PressureUsage.UsagePage, (ushort)(i + 1), preparsedData, hidReport);

                // If not, it isn't active.
                bool contactActive = contactUsages.Any();

                // Next, if we think it might be active, we check the pressure value.
                uint pressure = 0;

                if (contactActive)
                {
                    pressure =
                        Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PressureUsage, (ushort)(i + 1), preparsedData, hidReport);

                    // If it is below the minimum threshold, we change our minds.
                    if (pressure < MinimumDetectionPressure)
                        contactActive = false;
                }

                // If the contact isn't active, we don't need to check the x/y values.
                if (!contactActive)
                {
                    // If it was previously active, we fire the OnContactEnd event.
                    if (activeContacts[i])
                    {
                        OnContactEnd(new TouchpadEventArgs
                        {
                            ContactIndex = i
                        });

                        // ..and set it back to inactive
                        activeContacts[i] = false;
                    }

                    // Continue on to the next possible contact
                    continue;
                }

                // Okay, we've got a *for real* active contact. Let's check the x/y values.
                uint x = Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PositionXUsage, (ushort)(i + 1), preparsedData, hidReport);
                uint y = Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PositionYUsage, (ushort)(i + 1), preparsedData, hidReport);

                // We're going to either be calling OnContactStart or OnContactUpdate,
                // but with the same EventArgs either way. So let's go ahead and create it.
                TouchpadEventArgs e = new TouchpadEventArgs
                {
                    ContactIndex = i,
                    Pressure = pressure,
                    X = x,
                    Y = y
                };

                // Fire the appropriate event.
                if (activeContacts[i])
                {
                    OnContactUpdate(e);
                }
                else
                {
                    OnContactStart(e);

                    // This contact has started, and it is now active.
                    activeContacts[i] = true;
                }
            }
        }
    }
}
