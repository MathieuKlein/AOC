using System.Collections.Generic;

namespace D11SeatingSystem
{
    public class FerryTwo : FerryBase
    {
        public FerryTwo(IEnumerable<string> strings) : base(strings, 5)
        {
        }

        protected override char GetNextBackSeat(int i, int j)
        {
            for (var k = 1; i + k < MaxRow && j + k < MaxColumn; k++)
                switch (ArrayChar[i + k][j + k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetBackSeat(int i, int j)
        {
            for (var k = 1; i + k < MaxRow; k++)
                switch (ArrayChar[i + k][j])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetPreviousBackSeat(int i, int j)
        {
            var previousDown = Floor;
            for (var k = 1; i + k < MaxRow && j - k >= 0; k++)
                switch (ArrayChar[i + k][j - k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return previousDown;
        }

        protected override char GetNextFrontSeat(int i, int j)
        {
            for (var k = 1; i - k >= 0 && j + k < MaxColumn; k++)
                switch (ArrayChar[i - k][j + k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetFrontSeat(int i, int j)
        {
            for (var k = 1; i - k >= 0; k++)
                switch (ArrayChar[i - k][j])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetPreviousFrontSeat(int i, int j)
        {
            for (var k = 1; i - k >= 0 && j - k >= 0; k++)
                switch (ArrayChar[i - k][j - k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetNextSeat(int i, int j)
        {
            for (var k = 1; j + k < MaxColumn; k++)
                switch (ArrayChar[i][j + k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }

        protected override char GetPreviousSeat(int i, int j)
        {
            for (var k = 1; j - k >= 0; k++)
                switch (ArrayChar[i][j - k])
                {
                    case Occupied:
                        return Occupied;
                    case Empty:
                        return Empty;
                }

            return Floor;
        }
    }
}