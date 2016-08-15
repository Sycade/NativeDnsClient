using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(MxRecordStruct), DnsRecordType.Mx)]
    public class MxRecord : RecordBase, IPrioritizedRecord
    {
        public int Priority { get; set; }

        internal MxRecord(MxRecordStruct recordStruct)
            : base(Marshal.PtrToStringAuto(recordStruct.pNameExchange), recordStruct.dwTtl)
        {
            Priority = recordStruct.wPreference;
        }
    }
}
