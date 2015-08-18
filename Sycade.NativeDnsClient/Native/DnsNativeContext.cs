using Sycade.NativeDnsClient.RecordStructs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient.Native
{
    internal class DnsNativeContext : IDisposable
    {
        private IntPtr _queryResultsPtr = IntPtr.Zero;

        public void Dispose()
        {
            if (_queryResultsPtr != IntPtr.Zero)
                DnsRecordListFree(_queryResultsPtr, DnsFreeType.RecordList);
        }

        internal IRecordStruct[] Resolve(Type structType, string name, DnsRecordType type, DnsQueryOptions options)
        {
            var result = DnsQuery(ref name, type, options, IntPtr.Zero, ref _queryResultsPtr, IntPtr.Zero);

            if (result != 0)
                throw new DnsQueryException(result);

            var records = new List<IRecordStruct>();
            dynamic record;

            for (var recordPtr = _queryResultsPtr; recordPtr != IntPtr.Zero; recordPtr = record.pNext)
            {
                record = (dynamic)Marshal.PtrToStructure(recordPtr, structType);

                records.Add(record);
            }

            return records.ToArray();
        }

        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrName, DnsRecordType wType,
            DnsQueryOptions Options, IntPtr pExtra, ref IntPtr ppQueryResultsSet, IntPtr pReserved);

        [DllImport("dnsapi")]
        private static extern void DnsRecordListFree(IntPtr pRecordList, DnsFreeType FreeType);
    }
}
