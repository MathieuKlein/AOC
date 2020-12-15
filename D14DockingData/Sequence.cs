using System.Collections.Generic;

namespace D14DockingData
{
    public class Sequence
    {
        public Sequence(string mask)
        {
            Mask = mask;
        }

        public IDictionary<long, long> Memory { get; } = new Dictionary<long, long>();
        public string Mask { get; }
    }
}