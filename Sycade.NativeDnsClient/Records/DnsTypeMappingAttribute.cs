using System;

namespace Sycade.NativeDnsClient.Records
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    internal class DnsTypeMappingAttribute : Attribute
    {
        public Type StructType { get; set; }
        public DnsRecordType RecordType { get; set; }

        public DnsTypeMappingAttribute(Type structType, DnsRecordType recordType)
        {
            StructType = structType;
            RecordType = recordType;
        }
    }
}
