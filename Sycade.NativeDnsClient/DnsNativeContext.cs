using Sycade.NativeDnsClient.RecordStructs;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Sycade.NativeDnsClient
{
    internal class DnsNativeContext : IDisposable
    {
        private IntPtr _queryResultsPtr = IntPtr.Zero;

        public void Dispose()
        {
            if (_queryResultsPtr != IntPtr.Zero)
                DnsRecordListFree(_queryResultsPtr, 0);
        }

        internal IRecordStruct[] Resolve(Type structType, string name, DnsRecordType type, DnsQueryOptions options)
        {
            var result = DnsQuery(ref name, type, options, 0, ref _queryResultsPtr, 0);

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

        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrName, DnsRecordType wType, DnsQueryOptions Options,
            int pExtra, ref IntPtr ppQueryResultsSet, int pReserved);

        [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);
    }
}
