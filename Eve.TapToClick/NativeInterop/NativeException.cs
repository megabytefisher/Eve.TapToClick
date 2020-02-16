using System;
using System.Collections.Generic;
using System.Text;

namespace Eve.TapToClick.NativeInterop
{
    public class NativeException : Exception
    {
        public string NativeFunctionName { get; private set; }
        public int ErrorCode { get; private set; }

        public NativeException(string functionName, int errorCode) : base($"Error during native call to {functionName}. Error code: {errorCode}")
        {
            NativeFunctionName = functionName;
            ErrorCode = errorCode;
        }
    }
}
