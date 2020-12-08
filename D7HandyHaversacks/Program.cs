using System;
using System.IO;

namespace D7HandyHaversacks
{
    public class Program
    {
        public const string InputTxt = "input.txt";
        public const string ShinyGold = "shiny gold";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var bagRules = new BagRules(strings);

            Console.WriteLine(bagRules.GetBagThatCanContain(ShinyGold).Count);
            Console.WriteLine(bagRules.CountBagsInside(ShinyGold));

            Console.ReadKey();
        }
    }
}