using Sycade.NativeDnsClient.Native;
using Sycade.NativeDnsClient.Records;
using System;
using System.Linq;
using System.Reflection;

namespace Sycade.NativeDnsClient
{
    public static class DnsClient
    {
        public static TRecordType[] Resolve<TRecordType>(string name, DnsQueryOptions options = DnsQueryOptions.None)
            where TRecordType : RecordBase
        {
            var mappingAttribute = typeof(TRecordType).GetCustomAttribute<DnsTypeMappingAttribute>();

            if (mappingAttribute == null)
                throw new InvalidOperationException("No type mapping defined.");

            using (var context = new DnsNativeContext())
            {
                return context.Resolve(mappingAttribute.StructType, name, mappingAttribute.RecordType, options)
                              .Select(rs => (TRecordType)Activator.CreateInstance(typeof(TRecordType), BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { rs }, null))
                              .ToArray();
            }
        }
    }
}
