using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BinaryBoarding
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);
            var seatsId = strings.Select(GetSeatId).ToList();
            var value = seatsId.Max();

            Console.WriteLine(value);

            var missingSeat = GetMissingSeat(seatsId);

            Console.WriteLine(missingSeat);
            Console.ReadKey();
        }

        public static double GetMissingSeat(IEnumerable<double> seatsId)
        {
            var ordered = seatsId.OrderBy(x => x).ToList();

            return ordered.Where((x, index) => x + 1 != ordered[index + 1]).First() + 1;
        }

        public static double GetSeatId(string line)
        {
            double column = 0;
            double row = 0;
            var i = 6;
            double j = 2;
            foreach (var c in line)
            {
                switch (c)
                {
                    case 'B':
                        row += Math.Pow(2, i);
                        i--;
                        break;
                    case 'F':
                        i--;
                        break;
                    case 'R':
                        column += Math.Pow(2, j);
                        j--;
                        break;
                    case 'L':
                        j--;
                        break;
                }
            }

            var id = row * 8 + column;
            Debug.WriteLine($"{row} {column} {id}");
            return id;
        }
    }
}