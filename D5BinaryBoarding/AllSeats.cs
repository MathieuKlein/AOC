using System.Collections.Generic;
using System.Linq;

namespace BinaryBoarding
{
    public class AllSeats
    {
        private readonly IReadOnlyList<Seat> _lines;

        public AllSeats(IEnumerable<string> strings)
        {
            _lines = strings.Select(x => new Seat(x)).OrderBy(x => x.SeatId).ToList();
        }

        public double MaxSeatId() => _lines[^1].SeatId;

        public double FindMissingSeat() => _lines.Where((x, index) => x.SeatId + 1 != _lines[index + 1].SeatId).First().SeatId + 1;
    }
}