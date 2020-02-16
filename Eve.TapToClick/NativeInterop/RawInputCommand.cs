using System;
using System.Collections.Generic;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    public enum RawInputCommand
    {
        /// <summary>
        /// Get input data.
        /// </summary>
        Input = 0x10000003,
        /// <summary>
        /// Get header data.
        /// </summary>
        Header = 0x10000005
    }
}
