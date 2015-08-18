namespace Sycade.NativeDnsClient.Records
{
    public abstract class RecordBase
    {
        public int TimeToLive { get; }

        internal RecordBase(dynamic recordStruct)
        {
            TimeToLive = recordStruct.dwTtl;
        }
    }
}
