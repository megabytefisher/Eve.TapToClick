using System;
using System.Collections.Generic;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    public class RawInput
    {
        public RawInputHeader Header { get; set; }
        public RawInputData Data { get; set; }
        public byte[][] HidReports { get; set; }
    }
}
