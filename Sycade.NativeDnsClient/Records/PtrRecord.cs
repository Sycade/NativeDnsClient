using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(PtrRecordStruct), DnsRecordType.Ptr)]
    public class PtrRecord : RecordBase
    {
        public string Host { get; }

        internal PtrRecord(PtrRecordStruct recordStruct)
            : base(Marshal.PtrToStringAuto(recordStruct.pName), recordStruct.dwTtl)
        {
            Host = Marshal.PtrToStringAuto(recordStruct.pNameHost);
        }
    }
}
