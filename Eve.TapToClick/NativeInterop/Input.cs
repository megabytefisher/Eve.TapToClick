using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Input
    {
        public InputType Type;
        public InputUnion InputValue;

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            internal MouseInput MouseInput;

            [FieldOffset(0)]
            internal KeyboardInput KeyboardInput;

            [FieldOffset(0)]
            internal HardwareInput HardwareInput;
        }
    }
}
