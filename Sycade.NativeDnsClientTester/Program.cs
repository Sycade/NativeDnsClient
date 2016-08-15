using Sycade.NativeDnsClient;
using Sycade.NativeDnsClient.Records;
using Sycade.NativeDnsClient.Extensions;
using System;

namespace Sycade.NativeDnsClientTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var records = DnsClient.Resolve<SrvRecord>("sycade.com");

            records.OrderByPriorityAndWeight();

            foreach (var record in records)
                Console.WriteLine(record);
        }
    }
}
