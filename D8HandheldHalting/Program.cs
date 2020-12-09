using System;
using System.IO;

namespace D8HandheldHalting
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var bootLoader = new BootLoader(strings);

            var lastValueAccumulatorWhenFirstRoundEnd = bootLoader.GetLastValueAccumulatorWhenFirstRoundEnd();
            var lastValueAccumulatorWhenTerminates = bootLoader.GetLastValueAccumulatorWhenTerminates();

            Console.WriteLine(lastValueAccumulatorWhenFirstRoundEnd);
            Console.WriteLine(lastValueAccumulatorWhenTerminates);
            Console.ReadKey();
        }
    }
}