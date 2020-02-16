using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Explicit)]
    public struct RawInputData
    {
        [FieldOffset(0)]
        public RawInputHid HID;
    }
}
