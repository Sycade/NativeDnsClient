using Sycade.NativeDnsClient.RecordStructs;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Records
{
    public class MxRecord : RecordBase, IPrioritizedRecord
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        internal MxRecord(MxRecordStruct recordStruct)
            : base(recordStruct)
        {
            Name = Marshal.PtrToStringAuto(recordStruct.pNameExchange);

            Priority = recordStruct.wPreference;
        }
    }
}
