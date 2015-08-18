using System;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.RecordStructs
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct ARecordStruct : IRecordStruct
    {
        public IntPtr pNext;
        public IntPtr pName;
        public ushort wType;
        public ushort wDataLength;
        public int flags;
        public int dwTtl;
        public int dwReserved;

        public uint ipAddress;
    }
}
