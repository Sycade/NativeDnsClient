using System.ComponentModel;

namespace Sycade.NativeDnsClient
{
    public class DnsQueryException : Win32Exception
    {
        public DnsQueryException(int error) : base(error) { }
    }
}
