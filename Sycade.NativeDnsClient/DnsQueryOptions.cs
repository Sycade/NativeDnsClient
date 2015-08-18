using System;

namespace Sycade.NativeDnsClient
{
    [Flags]
    public enum DnsQueryOptions
    {
        None = 0x0,
        AcceptTruncatedResponse = 0x1,
        UseTcpOnly = 0x2,
        NoRecursion = 0x4,
        BypassCache = 0x8,
        NoWireQuery = 0x10,
        NoLocalName = 0x20,
        NoHostsFile = 0x40,
        NoNetbt = 0x80,
        WireOnly = 0x100,
        ReturnMessage = 0x200,
        MulticastOnly = 0x400,
        NoMulticast = 0x800,
        TreatAsFqdn = 0x1000,
        AddrConfig = 0x2000,
        DualAddr = 0x4000,
        MulticastWait = 0x20000,
        MulticastVerify = 0x40000,
        DoNotResetTtlValues = 0x100000,
        DisableIdnEncoding = 0x200000,
        AppendMultilabel = 0x800000,
    }
}
