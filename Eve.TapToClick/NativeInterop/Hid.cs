using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Eve.TapToClick.NativeInterop
{
    public static class Hid
    {
        [DllImport("hid.dll", SetLastError = true)]
        private static extern uint HidP_GetUsageValue(HidPReportType hidPReportType, ushort usagePage, ushort linkCollection, ushort usage, ref uint usageValue, byte[] preparsedData, byte[] report, uint reportLength);

        [DllImport("hid.dll", SetLastError = true)]
        private static extern uint HidP_GetUsages(HidPReportType hidPReportType, ushort usagePage, ushort linkCollection, ushort[] usageList, ref uint usageLength, byte[] preparsedData, byte[] report, uint reportLength);

        public static uint HidP_GetUsageValue(HidPReportType hidPReportType, ushort usagePage, ushort linkCollection, ushort usage, byte[] preparsedData, byte[] report)
        {
            uint result = 0;
            uint success = HidP_GetUsageValue(hidPReportType, usagePage, linkCollection, usage, ref result, preparsedData, report, (uint)report.Length);

            return result;
        }

        public static ushort[] HidP_GetUsages(HidPReportType hidPReportType, ushort usagePage, ushort linkCollection, byte[] preparsedData, byte[] report)
        {
            ushort[] usageList = new ushort[20];
            uint usageLength = (uint)usageList.Length;

            uint success = HidP_GetUsages(hidPReportType, usagePage, linkCollection, usageList, ref usageLength, preparsedData, report, (uint)report.Length);

            ushort[] results = new ushort[usageLength];
            Buffer.BlockCopy(usageList, 0, results, 0, (int)usageLength * 2);

            return results;
        }
    }
}
