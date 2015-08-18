using Sycade.NativeDnsClient;
using Sycade.NativeDnsClient.Records;
using System;

namespace Sycade.NativeDnsClientTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = DnsClient.Resolve<TxtRecord>("sycade.com");

            foreach (var record in records)
                Console.WriteLine(record);
        }
    }
}
