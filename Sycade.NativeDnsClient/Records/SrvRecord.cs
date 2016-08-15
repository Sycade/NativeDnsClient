using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(SrvRecordStruct), DnsRecordType.Srv)]
    public class SrvRecord : RecordBase, IWeightedRecord, IPrioritizedRecord
    {
        public string Name { get; }
        public int Priority { get; }
        public int Weight { get; }
        public int Port { get; }
        public string Target { get; }

        internal SrvRecord(SrvRecordStruct recordStruct)
            : base(recordStruct)
        {
            Name = Marshal.PtrToStringAuto(recordStruct.pName);
            Target = Marshal.PtrToStringAuto(recordStruct.pNameTarget);

            Priority = recordStruct.wPriority;
            Weight = recordStruct.wWeight;
            Port = recordStruct.wPort;
        }
    }
}
