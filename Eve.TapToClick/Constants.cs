using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick
{
    public static class Constants
    {
        public const ushort TargetDeviceUsagePage = 0x000D;
        public const ushort TargetDeviceUsage = 0x0005;

        public const ushort PressureUsagePage = 0x000D;
        public const ushort PressureUsage = 0x0030;

        public const ushort PositionXUsagePage = 0x0001;
        public const ushort PositionXUsage = 0x0030;

        public const ushort PositionYUsagePage = 0x0001;
        public const ushort PositionYUsage = 0x0031;
    }
}
