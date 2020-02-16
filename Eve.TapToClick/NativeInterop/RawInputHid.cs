using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RawInputHid
    {
        public int Size;
        public int Count;
    }
}
