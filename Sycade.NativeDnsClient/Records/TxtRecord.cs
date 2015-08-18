using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(TxtRecordStruct), DnsRecordType.Txt)]
    public class TxtRecord : RecordBase
    {
        public string Name { get; }
        public string Value { get; }

        internal TxtRecord(TxtRecordStruct recordStruct)
            : base(recordStruct)
        {
            Name = Marshal.PtrToStringAuto(recordStruct.pName);

            Value = Marshal.PtrToStringUni(recordStruct.pStringArray);
        }
    }
}
