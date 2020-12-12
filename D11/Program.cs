using System;
using System.IO;
using System.Linq;

namespace D11SeatingSystem
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var ferryOne = new FerryOne(strings);
            ferryOne.PlacePeople();

            var ferryTwo = new FerryTwo(strings);
            ferryTwo.PlacePeople();

            Console.WriteLine(ferryOne.CountOccupiedSeats());
            Console.WriteLine(ferryTwo.CountOccupiedSeats());

            Console.ReadKey();
        }
    }
}