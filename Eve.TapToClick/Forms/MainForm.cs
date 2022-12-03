﻿using Eve.TapToClick.Controls;
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
        // Indicates a single left click has been made but we haven't executed it yet so
        // we can wait to see if the user is double tapping and dragging.
        private bool pendingLeftClick = false;
        private bool dragging = false;

        private int initialMouseX;
        private int initialMouseY;
        private uint lastTouchX;
        private uint lastTouchY;
        private double remainderX;
        private double remainderY;
        private bool checkedForMissedMovement;
        private bool missedMovement;

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
            if (currentTap == null)
            {
                // This is a new tap, save some data to track missed movements.
                initialMouseX = MousePosition.X;
                initialMouseY = MousePosition.Y;
                lastTouchX = e.X;
                lastTouchY = e.Y;
                checkedForMissedMovement = false;
                missedMovement = false;
                remainderX = 0;
                remainderY = 0;
            }

            ProcessActiveContact(e);
        }

        private void HandleContactUpdate(object sender, TouchpadEventArgs e)
        {
            ProcessActiveContact(e);

            if (currentTap.MaximumActiveContacts == 1)
            {
                // Wait for significant touchpad movement before trying to measure mouse movement.
                if (!checkedForMissedMovement && (Math.Abs((int)e.X - (int)lastTouchX) > 10 || Math.Abs((int)e.Y - (int)lastTouchY) > 10))
                {
                    checkedForMissedMovement = true;
                    // The mouse hasn't updated yet. Wait a bit before checking. This isn't reliable but
                    // smaller values are less reliable.
                    System.Threading.Tasks.Task.Delay(config.MissedMovementMilliseconds).ContinueWith((task) => {
                        if (initialMouseX == MousePosition.X && initialMouseY == MousePosition.Y)
                            missedMovement = true;
                    });
                }
                if (missedMovement)
                {
                    // First, compute the scaled amount of distance the touch moved.
                    // Since touches are more detailed than pixels, add in remainder from last time.
                    double diffX = config.MissedMovementScale * ((double)e.X - lastTouchX) + remainderX;
                    double diffY = config.MissedMovementScale * ((double)e.Y - lastTouchY) + remainderY;
                    // Next, convert to whole pixels and save the remainder for next time.
                    int pixelsToMoveX = (int)Math.Round(diffX);
                    int pixelsToMoveY = (int)Math.Round(diffY);
                    remainderX = diffX - pixelsToMoveX;
                    remainderY = diffY - pixelsToMoveY;
                    lastTouchX = e.X;
                    lastTouchY = e.Y;
                    // Update the mouse position.
                    SendMouseUpdate(pixelsToMoveX, pixelsToMoveY);
                }
            }
        }

        private void ProcessActiveContact(TouchpadEventArgs eventArgs)
        {
            // If we're not inside an active 'tap', instantiate one.
            if (currentTap == null)
            {
                currentTap = new TapData(Constants.MaxContacts);

                // Check if we have a pending single click that hasn't been applied which might become a drag.
                if (pendingLeftClick)
                {
                    // We are below the double tap and drag threshold, enter special handling for double tap and drag
                    pendingLeftClick = false;
                    dragging = true;

                    // Send a left down to start dragging, which might turn into a normal click if this is just a double click
                    SendLeftDown();
                }
            }

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
            if (dragging)
            {
                // If we were dragging, we have a mouse down that we need to complete with an up.
                // If it was a normal double click, it will finish the first click before handling the
                // second click normally below. If it was a double tap and drag, then a second click
                // won't be registered below.
                SendLeftUp();
            }

            // If the tap object is null, just bail out
            if (currentTap == null)
                return;

            currentTap.InstantaneousActiveContacts[e.ContactIndex] = false;
            int currentActiveContacts = currentTap.InstantaneousActiveContacts.Count(ac => ac);

            // Has the tap ended?
            if (currentActiveContacts == 0)
            {
                currentTap.End = DateTime.Now;

                // Okay, was this *really* a tap?
                // We need to validate by checking the total duration, whether the pressure threshold was met,
                // and if the distance was within the maximum range.
                if ((currentTap.End - currentTap.Start).TotalMilliseconds <= config.MaxTapMilliseconds &&
                    currentTap.TapThresholdMet &&
                    currentTap.TotalContactDistances.Max() <= config.MaxTapDeltaPosition)
                {
                    // If it was a single-finger tap, inject a left click.
                    if (currentTap.MaximumActiveContacts == 1)
                    {
                        // We might double tap to drag, so don't send a single click until we've had a chance to find out.
                        pendingLeftClick = true;
                        System.Threading.Tasks.Task.Delay(config.MaxDoubleTapAndDragMilliseconds).ContinueWith((task) => {
                            if (pendingLeftClick)
                            {
                                pendingLeftClick = false;
                                SendLeftClick();
                                return;
                            }
                        });

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
                    previousDurationLabel.Text = ((int)(previousTap.End - previousTap.Start).TotalMilliseconds).ToString();
                    previousMaxDistanceLabel.Text = ((int)previousTap.TotalContactDistances.Max()).ToString();
                    previousContactCountLabel.Text = previousTap.MaximumActiveContacts.ToString();
                    doubleTapDragLabel.Text = dragging ? "Yes" : "No";
                    missedMovementLabel.Text = missedMovement ? "Yes" : "No";

                    previousMaxPressureLabel.ForeColor = previousTap.MaximumPressure >= config.TapTriggerThreshold
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousDurationLabel.ForeColor = (previousTap.End - previousTap.Start).TotalMilliseconds < config.MaxTapMilliseconds
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousMaxDistanceLabel.ForeColor = previousTap.TotalContactDistances.Max() < config.MaxTapDeltaPosition
                        ? Color.DarkGreen
                        : Color.DarkRed;
                    previousContactCountLabel.ForeColor = previousTap.MaximumActiveContacts >= 1 && previousTap.MaximumActiveContacts <= 3
                        ? Color.Green
                        : Color.DarkRed;
                    doubleTapDragLabel.ForeColor = dragging
                        ? Color.Green
                        : Color.DarkRed;
                    missedMovementLabel.ForeColor = missedMovement
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

        private void SendLeftDown()
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
            });
        }
        private void SendLeftUp()
        {
            User32.SendInput(new Input
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

        private void SendMouseUpdate(int X, int Y)
        {
            User32.SendInput(new Input
            {
                Type = InputType.Mouse,
                InputValue = new Input.InputUnion
                {
                    MouseInput = new MouseInput
                    {
                        DeltaX = X,
                        DeltaY = Y,
                        Flags = MouseInputFlag.Move
                    }
                }
            }); ;
        }

        private void SaveConfigValues()
        {
            bool detectionThresholdParsed = uint.TryParse(detectionThresholdTextBox.Text, out uint detectionThreshold);
            bool triggerThresholdParsed = uint.TryParse(triggerThresholdTextBox.Text, out uint triggerThreshold);
            bool maxMillisecondsParsed = int.TryParse(maxTapMillisecondsTextBox.Text, out int maxMilliseconds);
            bool maxDistanceParsed = int.TryParse(maxTapDistanceTextBox.Text, out int maxDistance);
            bool dragMillisecondsParsed = int.TryParse(dragGapTimeTextbox.Text, out int dragMilliseconds);
            bool missedMovementMillisecondsParsed = int.TryParse(missedMovementMillisecondsTextbox.Text, out int missedMovementMilliseconds);
            bool missedMovementScaleParsed = double.TryParse(missedMovementScaleFactorTextbox.Text, out double missedMovementScale);

            if (!detectionThresholdParsed || !triggerThresholdParsed || !maxMillisecondsParsed || !maxDistanceParsed || !dragMillisecondsParsed
                || !missedMovementMillisecondsParsed || !missedMovementScaleParsed)
            {
                MessageBox.Show("Invalid value entered in configuration.");
                LoadConfigValues();
                return;
            }

            config.DetectionThreshold = detectionThreshold;
            config.TapTriggerThreshold = triggerThreshold;
            config.MaxTapMilliseconds = maxMilliseconds;
            config.MaxTapDeltaPosition = maxDistance;
            config.MaxDoubleTapAndDragMilliseconds = dragMilliseconds;
            config.MissedMovementMilliseconds = missedMovementMilliseconds;
            config.MissedMovementScale = missedMovementScale;

            config.Save();
        }

        private void LoadConfigValues()
        {
            detectionThresholdTextBox.Text = config.DetectionThreshold.ToString();
            triggerThresholdTextBox.Text = config.TapTriggerThreshold.ToString();
            maxTapMillisecondsTextBox.Text = config.MaxTapMilliseconds.ToString();
            maxTapDistanceTextBox.Text = config.MaxTapDeltaPosition.ToString();
            dragGapTimeTextbox.Text = config.MaxDoubleTapAndDragMilliseconds.ToString();
            missedMovementMillisecondsTextbox.Text = config.MissedMovementMilliseconds.ToString();
            missedMovementScaleFactorTextbox.Text = config.MissedMovementScale.ToString();
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
