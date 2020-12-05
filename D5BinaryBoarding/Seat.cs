using System;

namespace BinaryBoarding
{
    public class Seat
    {
        private const int NumberOfLetterColumn = 7;
        private const int NumberOfLetterLine = 3;
        private const char Back = 'B';
        private const char Front = 'F';
        private const char Right = 'R';
        private const char Left = 'L';

        private readonly string _line;
        private readonly Lazy<double> _seatId;

        public Seat(string line)
        {
            _line = line;
            _seatId = new Lazy<double>(GetSeatId);
        }

        public double SeatId => _seatId.Value;

        private double GetSeatId()
        {
            var i = NumberOfLetterColumn;
            var j = NumberOfLetterLine;

            double column = 0;
            double row = 0;
            foreach (var c in _line)
                if (c == Back)
                    row += Math.Pow(2, --i);
                else if (c == Front)
                    i--;
                else if (c == Right)
                    column += Math.Pow(2, --j);
                else if (c == Left)
                    j--;

            return row * 8 + column;
        }
    }
}