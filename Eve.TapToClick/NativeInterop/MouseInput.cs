using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int DeltaX;
        public int DeltaY;
        public uint MouseData;
        public MouseInputFlag Flags;
        public uint Time;
        public IntPtr ExtraInfo;
    }
}
