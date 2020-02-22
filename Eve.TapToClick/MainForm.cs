using Eve.TapToClick.NativeInterop;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Eve.TapToClick
{
    public partial class MainForm : Form
    {
        private AppConfiguration config;

        private bool initialized = false;

        private DateTime? detectionStart;
        private bool triggerHit;
        private bool twoFinger;
        private uint? lastX;
        private uint? lastY;
        private uint maxTapPressure;
        private double deltaDistance;

        public MainForm()
        {
            InitializeComponent();
            config = AppConfiguration.Instance;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch ((WindowMessage)m.Msg)
            {
                case WindowMessage.WM_INPUT:
                    // Read raw input data
                    RawInput rawInput = User32.GetRawInputData(m.LParam, RawInputCommand.Input);

                    // Get preparsed data, which is used by hid.dll functions
                    byte[] preparsedData = User32.GetRawInputDeviceInfo(rawInput.Header.Device, DeviceInfoType.RIDI_PREPARSEDDATA);

                    // Check for active usages in the digitizer usage page on
                    // link collections 1 and 2. This is an easy way to determine
                    // whether the contacts are active - if there are active usages,
                    // it is active.
                    ushort[] firstContactUsages =
                        Hid.HidP_GetUsages(HidPReportType.HidP_Input, Constants.PressureUsagePage, 1, preparsedData, rawInput.HidReports[0]);
                    ushort[] secondContactUsages =
                        Hid.HidP_GetUsages(HidPReportType.HidP_Input, Constants.PressureUsagePage, 2, preparsedData, rawInput.HidReports[0]);

                    bool firstContactActive = firstContactUsages.Any();
                    bool secondContactActive = secondContactUsages.Any();

                    uint maxPressure = 0;
                    uint? firstContactX = null;
                    uint? firstContactY = null;

                    // If the first contact is active, read the pressure and X/Y position.
                    // Make sure pressure is above the detection threshold.
                    if (firstContactActive)
                    {
                        uint firstContactPressure =
                            Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PressureUsagePage, 1, Constants.PressureUsage, preparsedData, rawInput.HidReports[0]);

                        if (firstContactPressure >= config.DetectionThreshold)
                        {
                            maxPressure = firstContactPressure;

                            firstContactX =
                                Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PositionXUsagePage, 1, Constants.PositionXUsage, preparsedData, rawInput.HidReports[0]);
                            firstContactY =
                                Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PositionYUsagePage, 1, Constants.PositionYUsage, preparsedData, rawInput.HidReports[0]);
                        }
                        else
                        {
                            firstContactActive = false;
                        }
                    }

                    // If the second contact is active, read the pressure.
                    if (secondContactActive)
                    {
                        uint secondContactPressure =
                            Hid.HidP_GetUsageValue(HidPReportType.HidP_Input, Constants.PressureUsagePage, 2, Constants.PressureUsage, preparsedData, rawInput.HidReports[0]);

                        if (secondContactPressure >= config.DetectionThreshold)
                        {
                            maxPressure = Math.Max(maxPressure, secondContactPressure);
                        }
                        else
                        {
                            secondContactActive = false;
                        }
                    }

                    // If there's no active tap start time, and we've detected a contact,
                    // begin the "tap" by setting the start time to now.
                    if (!detectionStart.HasValue && firstContactActive)
                    {
                        detectionStart = DateTime.Now;
                    }

                    // If we're inside a tap...
                    if (detectionStart.HasValue)
                    {
                        // Update max recorded tap pressure, if needed.
                        maxTapPressure = Math.Max(maxPressure, maxTapPressure);

                        // If both contacts are active, set the twoFinger flag.
                        if (firstContactActive && secondContactActive)
                        {
                            twoFinger = true;
                        }

                        // If the pressure exceeds the trigger threshold, set that flag.
                        if (maxPressure >= config.TapTriggerThreshold)
                        {
                            triggerHit = true;
                        }

                        // Add the travel distance on the first contact.
                        if (lastX.HasValue && lastY.HasValue && firstContactX.HasValue && firstContactY.HasValue)
                        {
                            deltaDistance += Math.Sqrt(Math.Pow((double)lastX.Value - firstContactX.Value, 2) + Math.Pow((double)lastY.Value - firstContactY.Value, 2));
                        }

                        // If the first contact was active, set the last X/Y to the new values.
                        if (firstContactX.HasValue && firstContactY.HasValue)
                        {
                            lastX = firstContactX;
                            lastY = firstContactY;
                        }
                        else
                        {
                            lastX = null;
                            lastY = null;
                        }

                        // If we've fallen below the detection threshold...
                        if (maxPressure <= config.DetectionThreshold)
                        {
                            // Calculate the total milliseconds for the tap.
                            double tapDurationMilliseconds = (DateTime.Now - detectionStart.Value).TotalMilliseconds;

                            // If we hit the trigger threshold, are below the maximum time, and didn't exceed the
                            // maximum delta position, then we've just seen a tap.
                            if (triggerHit && tapDurationMilliseconds <= config.MaxTapMilliseconds &&
                                deltaDistance <= config.MaxTapDeltaPosition)
                            {
                                if (twoFinger)
                                {
                                    SendRightClick();
                                }
                                else
                                {
                                    SendLeftClick();
                                }
                            }

                            // Update form labels, if it is visible.
                            if (this.Visible)
                            {
                                maxPressureValueLabel.Text = maxTapPressure.ToString();
                                deltaDistanceLabel.Text = Math.Truncate(deltaDistance).ToString();
                                contactDurationLabel.Text = $"{Math.Truncate(tapDurationMilliseconds)} ms";
                                triggerHitCheckbox.Checked = triggerHit;
                                twoFingerCheckbox.Checked = twoFinger;
                                
                                maxPressureValueLabel.ForeColor = maxTapPressure >= config.TapTriggerThreshold ?
                                    Color.DarkGreen :
                                    Color.DarkRed;

                                deltaDistanceLabel.ForeColor = deltaDistance <= config.MaxTapDeltaPosition ?
                                    Color.DarkGreen :
                                    Color.DarkRed;

                                contactDurationLabel.ForeColor = tapDurationMilliseconds <= config.MaxTapMilliseconds ?
                                    Color.DarkGreen :
                                    Color.DarkRed;
                            }

                            // Since this tap is done, reset all values for the next one.
                            detectionStart = null;
                            triggerHit = false;
                            twoFinger = false;
                            lastX = null;
                            lastY = null;
                            maxTapPressure = 0;
                            deltaDistance = 0;
                        }
                    }

                    // If the form is visible, update labels.
                    if (this.Visible)
                    {
                        pressureValueLabel.Text = maxPressure.ToString();
                        firstXValueLabel.Text = firstContactX.ToString();
                        firstYValueLabel.Text = firstContactY.ToString();
                        firstContactActiveCheckbox.Checked = firstContactActive;
                        secondContactActiveCheckbox.Checked = secondContactActive;
                    }

                    break;
            }
        }

        private void SendLeftClick()
        {
            User32.SendInput(new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputFlag.LeftDown
                    }
                }
            },
            new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputFlag.LeftUp
                    }
                }
            });
        }

        private void SendRightClick()
        {
            User32.SendInput(new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputFlag.RightDown
                    }
                }
            },
            new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputFlag.RightUp
                    }
                }
            });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register to receive WM_INPUT messages for the specified HID device.
            User32.RegisterRawInputDevices(new RawInputDevice[]
            {
                new RawInputDevice
                {
                    UsagePage = Constants.TargetDeviceUsagePage,
                    Usage = Constants.TargetDeviceUsage,
                    Flags = RawInputDeviceFlags.InputSink,
                    WindowHandle = this.Handle
                }
            });

            LoadConfigValues();
            applyConfigButton.Enabled = false;

            // Check if we're already set to auto-run on system startup
            if (AutoRun.StartupTaskExists())
                startupCheckbox.Checked = true;

            initialized = true;
        }

        private void SaveConfigValues()
        {
            bool detectionThresholdParsed = uint.TryParse(detectionThresholdTextBox.Text, out uint detectionThreshold);
            bool triggerThresholdParsed = uint.TryParse(triggerThresholdTextBox.Text, out uint triggerThreshold);
            bool maxMillisecondsParsed = int.TryParse(maxTapMillisecondsTextBox.Text, out int maxMilliseconds);
            bool maxDistanceParsed = int.TryParse(maxTapDistanceTextBox.Text, out int maxDistance);

            if (!detectionThresholdParsed || !triggerThresholdParsed || !maxMillisecondsParsed || !maxDistanceParsed)
            {
                MessageBox.Show("Invalid value entered in configuration.");
                LoadConfigValues();
                return;
            }

            config.DetectionThreshold = detectionThreshold;
            config.TapTriggerThreshold = triggerThreshold;
            config.MaxTapMilliseconds = maxMilliseconds;
            config.MaxTapDeltaPosition = maxDistance;

            config.Save();
        }

        private void LoadConfigValues()
        {
            detectionThresholdTextBox.Text = config.DetectionThreshold.ToString();
            triggerThresholdTextBox.Text = config.TapTriggerThreshold.ToString();
            maxTapMillisecondsTextBox.Text = config.MaxTapMilliseconds.ToString();
            maxTapDistanceTextBox.Text = config.MaxTapDeltaPosition.ToString();
        }

        private void applyConfigButton_Click(object sender, EventArgs e)
        {
            SaveConfigValues();
            applyConfigButton.Enabled = false;
        }

        private void configTextBox_TextChanged(object sender, EventArgs e)
        {
            applyConfigButton.Enabled = true;
        }

        private void notifyIconConfigureMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void notifyIconExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void startupCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // If the form isn't done loading, ignore change events.
            if (!initialized)
                return;

            AutoRun.RemoveStartupTask();

            // If we're checked, add the task.
            // Just a note: we use task scheduler here as opposed to the "Startup" folder
            // or the registry, because those solutions will cause UAC prompt on startup.
            if (startupCheckbox.Checked)
            {
                AutoRun.AddStartupTask();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Should we start minimized?
            // We do this in the "Shown" event handle, because
            // the "Resize" event isn't fired when we do this
            // inside the "Load" event handler.
            if (Environment.GetCommandLineArgs().Any(s => s.ToLower() == "--minimize"))
                WindowState = FormWindowState.Minimized;
        }
    }
}
