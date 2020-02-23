using Eve.TapToClick.NativeInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick
{
    public static class Constants
    {
        public static readonly UsageDescriptor TargetDeviceUsage = new UsageDescriptor(0x000D, 0x005);
        public static readonly UsageDescriptor PressureUsage = new UsageDescriptor(0x000D, 0x0030);
        public static readonly UsageDescriptor PositionXUsage = new UsageDescriptor(0x0001, 0x0030);
        public static readonly UsageDescriptor PositionYUsage = new UsageDescriptor(0x0001, 0x0031);

        public const int MaxContacts = 5;
    }
}
