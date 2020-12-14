using System.Collections.Generic;
using System.Linq;

namespace D13ShuttleSearch
{
    public class Buses
    {
        private const string OutOfService = "x";
        private readonly Dictionary<long, Bus> _busDict = new Dictionary<long, Bus>();

        public Buses(IEnumerable<string> busesStrings)
        {
            var index = -1;
            foreach (var busString in busesStrings)
            {
                index++;
                if (busString == OutOfService)
                    continue;
                var bus = new Bus(busString);
                _busDict.Add(index, bus);
            }
        }

        public (Bus Bus, long NextIn) MinNextBus(long timestamp)
        {
            return _busDict.Values.Select(x => (Bus: x, NextIn: 0L)).Aggregate((a, b) =>
            {
                var nextBus1 = a.Bus.NextIn(timestamp);
                var nextBus2 = b.Bus.NextIn(timestamp);
                return nextBus1 < nextBus2 ? (a.Bus, nextBus1) : (b.Bus, nextBus2);
            });
        }

        public long MinTimestampWhenBusesAreInCorrectPosition()
        {
            var timestamp = 100000000000000L + _busDict[0].NextIn(100000000000000L);
            var skip = _busDict[0].Frequency;

            foreach (var bus in _busDict.Skip(1))
            {
                var position = bus.Key;
                var frequency = bus.Value.Frequency;

                while (bus.Value.NextIn(timestamp) % frequency != position % frequency)
                    timestamp += skip;

                skip *= frequency;
            }

            return timestamp;
        }
    }
}