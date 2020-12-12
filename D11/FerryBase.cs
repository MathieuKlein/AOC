using System.Collections.Generic;
using System.Linq;

namespace D11SeatingSystem
{
    public abstract class FerryBase
    {
        public const char Floor = '.';
        public const char Empty = 'L';
        public const char Occupied = '#';
        protected char[][] ArrayChar;
        protected readonly int Tolerance;

        protected FerryBase(IEnumerable<string> strings, int tolerance)
        {
            ArrayChar = strings.Select(x => x.ToCharArray()).ToArray();
            Tolerance = tolerance;
        }

        protected int MaxRow => ArrayChar.Length;
        protected int MaxColumn => ArrayChar[0].Length;

        protected abstract char GetNextBackSeat(int i, int j);
        protected abstract char GetBackSeat(int i, int j);
        protected abstract char GetPreviousBackSeat(int i, int j);
        protected abstract char GetNextFrontSeat(int i, int j);
        protected abstract char GetFrontSeat(int i, int j);
        protected abstract char GetPreviousFrontSeat(int i, int j);
        protected abstract char GetNextSeat(int i, int j);
        protected abstract char GetPreviousSeat(int i, int j);

        public int CountOccupiedSeats()
        {
            return ArrayChar.SelectMany(x => x).Count(x => x == Occupied);
        }

        public char[][] PlacePeople()
        {
            var arraCharTemp = ArrayChar.Select(x => x.ToArray()).ToArray();

            var somethingChanged = true;
            while (somethingChanged)
            {
                somethingChanged = false;
                for (var i = 0; i < ArrayChar.Length; i++)
                for (var j = 0; j < ArrayChar[i].Length; j++)
                {
                    var seat = ArrayChar[i][j];
                    var previous = GetPreviousSeat(i, j);
                    var next = GetNextSeat(i, j);
                    var previousUp = GetPreviousFrontSeat(i, j);
                    var up = GetFrontSeat(i, j);
                    var nextFrontSeat = GetNextFrontSeat(i, j);
                    var previousBackSeat = GetPreviousBackSeat(i, j);
                    var backSeat = GetBackSeat(i, j);
                    var nextBackSeat = GetNextBackSeat(i, j);

                    var adjacentSeats = new List<char>
                    {
                        previous, previousBackSeat, previousUp, nextBackSeat, nextFrontSeat, next, up, backSeat
                    };

                    if (seat == Empty && adjacentSeats.All(x => x != Occupied))
                    {
                        arraCharTemp[i][j] = Occupied;
                        somethingChanged = true;
                    }
                    else if (seat == Occupied && adjacentSeats.Count(x => x == Occupied) >= Tolerance)
                    {
                        arraCharTemp[i][j] = Empty;
                        somethingChanged = true;
                    }
                }

                ArrayChar = arraCharTemp.Select(x => x.ToArray()).ToArray();
            }

            return ArrayChar;
        }
    }
}