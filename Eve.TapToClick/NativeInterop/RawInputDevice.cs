using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    /// <summary>Value type for raw input devices.</summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RawInputDevice
    {
        /// <summary>Top level collection Usage page for the raw input device.</summary>
        public ushort UsagePage;
        /// <summary>Top level collection Usage for the raw input device. </summary>
        public ushort Usage;
        /// <summary>Mode flag that specifies how to interpret the information provided by UsagePage and Usage.</summary>
        public RawInputDeviceFlags Flags;
        /// <summary>Handle to the target device. If NULL, it follows the keyboard focus.</summary>
        public IntPtr WindowHandle;
    }
}
