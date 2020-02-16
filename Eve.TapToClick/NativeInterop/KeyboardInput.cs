using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public ushort VirtualKeyCode;
        public ushort HardwareScanCode;
        public uint Flags;
        public uint Time;
        public IntPtr ExtraInfo;
    }
}
