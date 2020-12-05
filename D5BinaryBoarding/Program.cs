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
            var allSeats = new AllSeats(strings);

            Console.WriteLine(allSeats.MaxSeatId());
            Console.WriteLine(allSeats.FindMissingSeat());
            Console.ReadKey();
        }
    }
}