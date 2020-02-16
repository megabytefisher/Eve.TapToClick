using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    public static class Utilities
    {
        public static T ByteArryToStruct<T>(byte[] bytes, int offset = 0) where T : struct
        {
            T structure;

            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                structure = Marshal.PtrToStructure<T>(handle.AddrOfPinnedObject() + offset);
            }
            finally
            {
                handle.Free();
            }

            return structure;
        }
    }
}
