using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    public static class User32
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool RegisterRawInputDevices([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] RawInputDevice[] pRawInputDevices, int uiNumDevices, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputDeviceInfo(IntPtr hDevice, DeviceInfoType uiCommand, byte[] pData, ref uint pcbSize);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetRawInputData(IntPtr hRawInput, RawInputCommand uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint cInputs, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]Input[] inputs, int cbSize);

        public static void RegisterRawInputDevices(RawInputDevice[] rawInputDevices)
        {
            bool success = RegisterRawInputDevices(rawInputDevices, rawInputDevices.Length, Marshal.SizeOf<RawInputDevice>());

            if (!success)
            {
                throw new NativeException("RegisterRawInputDevices", Marshal.GetLastWin32Error());
            }
        }

        public static byte[] GetRawInputDeviceInfo(IntPtr deviceHandle, DeviceInfoType uiCommand)
        {
            uint bufferSize = 0;
            uint wroteLength = GetRawInputDeviceInfo(deviceHandle, uiCommand, null, ref bufferSize);

            if (bufferSize <= 0 || wroteLength < 0)
            {
                throw new NativeException("GetRawInputDeviceInfo", Marshal.GetLastWin32Error());
            }

            byte[] buffer = new byte[bufferSize];
            wroteLength = GetRawInputDeviceInfo(deviceHandle, uiCommand, buffer, ref bufferSize);

            if (wroteLength != bufferSize)
            {
                throw new NativeException("GetRawInputDeviceInfo", Marshal.GetLastWin32Error());
            }

            return buffer;
        }

        public static RawInput GetRawInputData(IntPtr rawInputHandle, RawInputCommand uiCommand)
        {
            uint bufferSize = 0;
            uint wroteLength = GetRawInputData(rawInputHandle, uiCommand, IntPtr.Zero, ref bufferSize, (uint)Marshal.SizeOf<RawInputHeader>());

            if (bufferSize <= 0 || wroteLength < 0)
            {
                throw new NativeException("GetRawInputData", Marshal.GetLastWin32Error());
            }

            //byte[] buffer = new byte[bufferSize];

            IntPtr pData = Marshal.AllocHGlobal((int)bufferSize);
            try
            {
                wroteLength = GetRawInputData(rawInputHandle, uiCommand, pData, ref bufferSize, (uint)Marshal.SizeOf<RawInputHeader>());

                if (wroteLength != bufferSize)
                {
                    throw new NativeException("GetRawInputData", Marshal.GetLastWin32Error());
                }

                RawInput result = new RawInput();
                result.Header = Marshal.PtrToStructure<RawInputHeader>(pData);
                result.Data = Marshal.PtrToStructure<RawInputData>(pData + Marshal.SizeOf<RawInputHeader>());

                if (result.Header.Type == RawInputType.HID)
                {
                    result.HidReports = new byte[result.Data.HID.Count][];

                    // Read the HID reports
                    for (int i = 0; i < result.Data.HID.Count; i++)
                    {
                        IntPtr currentData = pData + Marshal.SizeOf<RawInputHeader>() + Marshal.SizeOf<RawInputHid>() + (i * result.Data.HID.Size);
                        result.HidReports[i] = new byte[result.Data.HID.Size];

                        Marshal.Copy(currentData, result.HidReports[i], 0, result.Data.HID.Size);
                    }
                }

                return result;
            }
            finally
            {
                Marshal.FreeHGlobal(pData);
            }
        }

        public static void SendInput(params Input[] inputs)
        {
            uint result = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<Input>());

            if (result != inputs.Length)
            {
                throw new NativeException("SendInput", Marshal.GetLastWin32Error());
            }
        }
    }
}
