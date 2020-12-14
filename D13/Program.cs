using System;
using System.IO;
using System.Linq;

namespace D13ShuttleSearch
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var timestamp = long.Parse(strings.First());
            var busesStrings = strings.Skip(1).First().Split(',');
            var buses = new Buses(busesStrings);

            var (bus, nextIn) = buses.MinNextBus(timestamp);
            Console.WriteLine(bus.Frequency * nextIn);

            Console.WriteLine(buses.MinTimestampWhenBusesAreInCorrectPosition());

            Console.ReadKey();
        }
    }
}