using Sycade.NativeDnsClient.Records;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sycade.NativeDnsClient.Extensions
{
    public static class RecordEnumerableExtensions
    {
        public static IEnumerable<TRecord> OrderByPriorityAndWeight<TRecord>(this IEnumerable<TRecord> recordList)
            where TRecord : IPrioritizedRecord, IWeightedRecord
        {
            // Group records by priority and set running weight
            var runningWeight = 0;

            var recordsByPriority = recordList.GroupBy(r => r.Priority).Select(gr => new
            {
                Priority = gr.Key,
                Records = gr.OrderBy(r => r.Weight).Select(r => new
                {
                    Record = r,
                    RunningWeight = runningWeight += r.Weight
                }).ToList()
            }).OrderBy(r => r.Priority);

            // Select record by weight
            var rng = new Random();

            foreach (var records in recordsByPriority.Select(rbp => rbp.Records))
            {
                // Loop through all records
                var recordCount = records.Count;

                for (int i = 0; i < recordCount; i++)
                {
                    var randomWeight = rng.Next(0, records.Max(r => r.RunningWeight));

                    var weightedRecord = records.First(r => r.RunningWeight > randomWeight);
                    records.Remove(weightedRecord); // Delete from the list so it will not be selected again

                    yield return weightedRecord.Record;
                }
            }
        }
    }
}
