using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick
{
    public class TouchpadEventArgs
    {
        public int ContactIndex { get; set; }
        public uint Pressure { get; set; }
        public uint X { get; set; }
        public uint Y { get; set; }
    }
}
