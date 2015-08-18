using Sycade.NativeDnsClient;
using Sycade.NativeDnsClient.Records;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = DnsClient.Resolve<ARecord>("_betp._tls.sycade.com");

            System.Console.WriteLine(records);
        }
    }
}
