using Sycade.NativeDnsClient.RecordStructs;
using System.Net;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(ARecordStruct), DnsRecordType.A)]
    public class ARecord : RecordBase
    {
        public string Name { get; }
        public IPAddress IpAddress { get; }

        internal ARecord(ARecordStruct recordStruct)
            : base(recordStruct)
        {
            Name = Marshal.PtrToStringAuto(recordStruct.pName);
            IpAddress = new IPAddress(recordStruct.ipAddress);
        }
    }
}
