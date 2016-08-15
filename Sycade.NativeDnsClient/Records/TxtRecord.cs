using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(TxtRecordStruct), DnsRecordType.Txt)]
    public class TxtRecord : RecordBase
    {
        public string Value { get; }

        internal TxtRecord(TxtRecordStruct recordStruct)
            : base(Marshal.PtrToStringAuto(recordStruct.pName), recordStruct.dwTtl)
        {
            Value = Marshal.PtrToStringAuto(recordStruct.pStringArray);
        }
    }
}
