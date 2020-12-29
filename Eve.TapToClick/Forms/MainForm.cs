using Eve.TapToClick.Controls;
using Eve.TapToClick.Models;
using Eve.TapToClick.NativeInterop;
using Eve.TapToClick.Utilities;
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

namespace Eve.TapToClick.Forms
{
    public partial class MainForm : Form
    {
        private AppConfiguration config;
        private TouchpadWatcher touchpadWatcher;
        private ActiveContactDisplay[] activeContactDisplays;
        private DateTime?[] lastActiveContactUiUpdates;

        private bool initialized = false;

        private TapData currentTap;
        private TapData previousTap;

        public MainForm()
        {
            InitializeComponent();

            // Load the config instance and store a ref
            config = AppConfiguration.Instance;

            // Initialize TouchpadWatcher and hook into events
            touchpadWatcher = new TouchpadWatcher();
            touchpadWatcher.MinimumDetectionPressure = config.DetectionThreshold;
            touchpadWatcher.ContactStart += HandleContactStart;
            touchpadWatcher.ContactUpdate += HandleContactUpdate;
            touchpadWatcher.ContactEnd += HandleContactEnd;

            // We keep track of when we last updated each
            // contact display, so we can throttle UI updates
            // while the mouse is moving. This keeps the program
            // from using too much CPU
            lastActiveContactUiUpdates = new DateTime?[Constants.MaxContacts];

            // Create an array of the active contact displays
            // for easy access later
            activeContactDisplays = new ActiveContactDisplay[]
            {
                activeContactDisplay1,
                activeContactDisplay2,
                activeContactDisplay3,
                activeContactDisplay4,
                activeContactDisplay5
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Register to receive WM_INPUT messages for the specified HID device.
            User32.RegisterRawInputDevices(new RawInputDevice[]
            {
                new RawInputDevice
                {
                    UsagePage = Constants.TargetDeviceUsage.UsagePage,
                    Usage = Constants.TargetDeviceUsage.Usage,
                    Flags = RawInputDeviceFlags.InputSink,
                    WindowHandle = this.Handle
                }
            });

            // Load the config values into the text boxes
            LoadConfigValues();

            // Disable the apply button until a change is detected
            applyConfigButton.Enabled = false;

            // Check if we're already set to auto-run on system startup
            if (AutoRun.StartupTaskExists())
                startupCheckbox.Checked = true;

            initialized = true;
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

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // We look for raw input messages here and pass them 
            // to the TouchpadWatcher, where they are processed into
            // the events below.
            switch ((WindowMessage)m.Msg)
            {
                case WindowMessage.WM_INPUT:
                    touchpadWatcher.HandleInputMessage(ref m);

                    break;
            }
        }

        // Originally, I thought I would need to handle these two types of events
        // independently, but that didn't turn out to be the case.
        private void HandleContactStart(object sender, TouchpadEventArgs e)
        {
            ProcessActiveContact(e);
        }

        private void HandleContactUpdate(object sender, TouchpadEventArgs e)
        {
            ProcessActiveContact(e);
        }

        private void ProcessActiveContact(TouchpadEventArgs eventArgs)
        {
            // If we're not inside an active 'tap', instantiate one.
            if (currentTap == null)
                currentTap = new TapData(Constants.MaxContacts);

            bool wasActive = currentTap.InstantaneousActiveContacts[eventArgs.ContactIndex];
            currentTap.InstantaneousActiveContacts[eventArgs.ContactIndex] = true;

            // If we were previously active, add the distance from the last X/Y
            // to this new one to the total distance in the tap object.
            if (wasActive)
            {
                uint previousX = currentTap.PreviousXValues[eventArgs.ContactIndex];
                uint previousY = currentTap.PreviousYValues[eventArgs.ContactIndex];

                double positionDelta = Math.Sqrt(Math.Pow((double)eventArgs.X - previousX, 2) + Math.Pow((double)eventArgs.Y - previousY, 2));
                currentTap.TotalContactDistances[eventArgs.ContactIndex] += positionDelta;
            }

            currentTap.MaximumActiveContacts = Math.Max(currentTap.InstantaneousActiveContacts.Count(ac => ac), currentTap.MaximumActiveContacts);
            currentTap.MaximumPressure = Math.Max(currentTap.MaximumPressure, eventArgs.Pressure);

            currentTap.PreviousXValues[eventArgs.ContactIndex] = eventArgs.X;
            currentTap.PreviousYValues[eventArgs.ContactIndex] = eventArgs.Y;

            if (eventArgs.Pressure >= config.TapTriggerThreshold)
            {
                currentTap.TapThresholdMet = true;
            }

            // If we're not minimized, update the form values
            if (WindowState != FormWindowState.Minimized &&
                (!lastActiveContactUiUpdates[eventArgs.ContactIndex].HasValue || (DateTime.Now - lastActiveContactUiUpdates[eventArgs.ContactIndex].Value).TotalMilliseconds >= 50))
            {
                ActiveContactDisplay contactDisplay = activeContactDisplays[eventArgs.ContactIndex];

                contactDisplay.Active = true;
                contactDisplay.Pressure = eventArgs.Pressure;
                contactDisplay.X = eventArgs.X;
                contactDisplay.Y = eventArgs.Y;

                lastActiveContactUiUpdates[eventArgs.ContactIndex] = DateTime.Now;
            }
        }

        private void HandleContactEnd(object sender, TouchpadEventArgs e)
        {
            // If the tap object is null, just bail out
            if (currentTap == null)
                return;

            currentTap.InstantaneousActiveContacts[e.ContactIndex] = false;
            int currentActiveContacts = currentTap.InstantaneousActiveContacts.Count(ac => ac);

            // Has the tap ended?
            if (currentActiveContacts == 0)
            {
                DateTime tapEnd = DateTime.Now;

                // Okay, was this *really* a tap?
                // We need to validate by checking the total duration, whether the pressure threshold was met,
                // and if the distance was within the maximum range.
                if ((tapEnd - currentTap.Start).TotalMilliseconds <= config.MaxTapMilliseconds &&
                    currentTap.TapThresholdMet &&
                    currentTap.TotalContactDistances.Max() <= config.MaxTapDeltaPosition)
                {
                    // If it was a single-finger tap, inject a left click.
                    if (currentTap.MaximumActiveContacts == 1)
                    {
                        SendLeftClick();
                    }
                    // If it was a double-finger tap, inject a right click.
                    else if (currentTap.MaximumActiveContacts == 2)
                    {
                        SendRightClick();
                    }
                    else if (currentTap.MaximumActiveContacts == 3)
                    {
                        SendMiddleClick();
                    }
                }

                // Store reference to previous tap. Will probably need this later
                // if we want to add in support for double-tap-and-drag.
                previousTap = currentTap;

                // Clear out current tap, for it is over and done
                currentTap = null;

                // If we're not minimized, update form values
                if (WindowState != FormWindowState.Minimized)
                {
                    // Update previous tap display
                    previousMaxPressureLabel.Text = previousTap.MaximumPressure.ToString();
                    previousDurationLabel.Text = ((int)(tapEnd - previousTap.Start).TotalMilliseconds).ToString();
                    previousMaxDistanceLabel.Text = ((int)previousTap.TotalContactDistances.Max()).ToString();
                    previousContactCountLabel.Text = previousTap.MaximumActiveContacts.ToString();

                    previousMaxPressureLabel.ForeColor = previousTap.MaximumPressure >= config.TapTriggerThreshold
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousDurationLabel.ForeColor = (tapEnd - previousTap.Start).TotalMilliseconds < config.MaxTapMilliseconds
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousMaxDistanceLabel.ForeColor = previousTap.TotalContactDistances.Max() < config.MaxTapDeltaPosition
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousContactCountLabel.ForeColor = previousTap.MaximumActiveContacts >= 1 && previousTap.MaximumActiveContacts <= 3
                        ? Color.Green
                        : Color.DarkRed;
                }
            }

            if (WindowState != FormWindowState.Minimized)
            {
                ActiveContactDisplay contactDisplay = activeContactDisplays[e.ContactIndex];

                contactDisplay.Active = false;
                contactDisplay.Pressure = 0;
                contactDisplay.X = 0;
                contactDisplay.Y = 0;
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

        private void SendMiddleClick()
        {
            User32.SendInput(new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        Flags = MouseInputFlag.MiddleDown
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
                        Flags = MouseInputFlag.MiddleUp
                    }
                }
            });
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
            touchpadWatcher.MinimumDetectionPressure = config.DetectionThreshold;
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
    }
}
