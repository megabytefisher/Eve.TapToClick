using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)]
        public InputType Type;

        [FieldOffset(4)]
        public MouseInput MouseInput;

        [FieldOffset(4)]
        public KeyboardInput KeyboardInput;

        [FieldOffset(4)]
        public HardwareInput HardwareInput;
    }
}
