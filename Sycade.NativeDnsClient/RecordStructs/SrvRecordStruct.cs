using System;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.RecordStructs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SrvRecordStruct : IRecordStruct
    {
        public IntPtr pNext;
        public IntPtr pName;
        public ushort wType;
        public ushort wDataLength;
        public int flags;
        public int dwTtl;
        public int dwReserved;

        public IntPtr pNameTarget;
        public ushort wPriority;
        public ushort wWeight;
        public ushort wPort;
        public ushort Pad;
    }
}
