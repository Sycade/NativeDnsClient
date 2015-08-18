using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(PtrRecordStruct), DnsRecordType.Ptr)]
    public class PtrRecord : RecordBase
    {
        public string Name { get; }
        public string Host { get; }

        internal PtrRecord(PtrRecordStruct recordStruct)
            : base(recordStruct)
        {
            Name = Marshal.PtrToStringAuto(recordStruct.pName);
            Host = Marshal.PtrToStringAuto(recordStruct.pNameHost);
        }
    }
}
