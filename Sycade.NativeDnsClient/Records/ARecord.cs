using Sycade.NativeDnsClient.RecordStructs;
using System.Net;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    [DnsTypeMapping(typeof(ARecordStruct), DnsRecordType.A)]
    public class ARecord : RecordBase
    {
        public IPAddress IpAddress { get; }

        internal ARecord(ARecordStruct recordStruct)
            : base(Marshal.PtrToStringAuto(recordStruct.pName), recordStruct.dwTtl)
        {
            IpAddress = new IPAddress(recordStruct.ipAddress);
        }
    }
}
