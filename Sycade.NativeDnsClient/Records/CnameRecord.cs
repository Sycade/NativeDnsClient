using Sycade.NativeDnsClient.RecordStructs;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(PtrRecordStruct), DnsRecordType.Cname)]
    public class CnameRecord : PtrRecord
    {
        internal CnameRecord(PtrRecordStruct recordStruct) : base(recordStruct) { }
    }
}
