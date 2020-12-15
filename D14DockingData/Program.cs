using System;
using System.IO;
using System.Linq;

namespace D14DockingData
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            DockDecoderBase decoder = new DockDecoderV1(strings);

            Console.WriteLine(decoder.Decode().Values.Sum());

            decoder = new DockDecoderV2(strings);

            Console.WriteLine(decoder.Decode().Values.Sum());
        }
    }
}