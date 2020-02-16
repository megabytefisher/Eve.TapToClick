using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    public enum MouseInputFlag
    {
        AbsolutePosition            = 0x8000,
        HorizontalWheel             = 0x1000,
        Move                        = 0x0001,
        MoveNoCoalesce              = 0x2000,
        LeftDown                    = 0x0002,
        LeftUp                      = 0x0004,
        RightDown                   = 0x0008,
        RightUp                     = 0x0010,
        MiddleDown                  = 0x0020,
        MiddleUp                    = 0x0040,
        VirtualDesk                 = 0x4000,
        XDown                       = 0x0080,
        XUp                         = 0x0100,
    }
}
