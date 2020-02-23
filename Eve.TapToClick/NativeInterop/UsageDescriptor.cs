using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    public class UsageDescriptor
    {
        public readonly ushort UsagePage;
        public readonly ushort Usage;

        public UsageDescriptor(ushort usagePage, ushort usage)
        {
            UsagePage = usagePage;
            Usage = usage;
        }
    }
}
