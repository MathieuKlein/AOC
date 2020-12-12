using System.Collections.Generic;

namespace D11SeatingSystem
{
    public class FerryOne : FerryBase
    {
        public FerryOne(IEnumerable<string> strings) : base(strings, 4)
        {
        }


        protected override char GetPreviousSeat(int i, int j)
        {
            return IsAboveMinColumn(j) ? ArrayChar[i][j - 1] : Floor;
        }

        protected override char GetPreviousBackSeat(int i, int j)
        {
            return IsBelowMaxRow(i) && IsAboveMinColumn(j) ? ArrayChar[i + 1][j - 1] : Floor;
        }

        protected override char GetBackSeat(int i, int j)
        {
            return IsBelowMaxRow(i) ? ArrayChar[i + 1][j] : Floor;
        }

        protected override char GetNextBackSeat(int i, int j)
        {
            return IsBelowMaxRow(i) && IsBelowMaxColumn(j) ? ArrayChar[i + 1][j + 1] : Floor;
        }

        protected override char GetNextSeat(int i, int j)
        {
            return IsBelowMaxColumn(j) ? ArrayChar[i][j + 1] : Floor;
        }

        protected override char GetNextFrontSeat(int i, int j)
        {
            return IsAboveMinRow(i) && IsBelowMaxColumn(j) ? ArrayChar[i - 1][j + 1] : Floor;
        }

        protected override char GetFrontSeat(int i, int j)
        {
            return IsAboveMinRow(i) ? ArrayChar[i - 1][j] : Floor;
        }

        protected override char GetPreviousFrontSeat(int i, int j)
        {
            return IsAboveMinRow(i) && IsAboveMinColumn(j) ? ArrayChar[i - 1][j - 1] : Floor;
        }

        private bool IsBelowMaxColumn(int j)
        {
            return j + 1 < MaxColumn;
        }

        private bool IsBelowMaxRow(int i)
        {
            return i + 1 < MaxRow;
        }

        private static bool IsAboveMinColumn(int j)
        {
            return j - 1 >= 0;
        }

        private static bool IsAboveMinRow(int i)
        {
            return i - 1 >= 0;
        }
    }
}