namespace Sycade.NativeDnsClient.Records
{
    public abstract class RecordBase
    {
        public string Name { get; }
        public int TimeToLive { get; }

        internal RecordBase(string name, int ttl)
        {
            Name = name;
            TimeToLive = ttl;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
