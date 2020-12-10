using System;
using System.IO;
using System.Linq;

namespace D9EncodingError
{
    public class Program
    {
        public const string InputTxt = "input.txt";
        private const int Key = 25;

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);

            var decryptor = new Decryptor(strings);

            var firstNumberNotEqualToNPrecedent = decryptor.GetFirstNumberNotEqualToNPrecedent(Key);
            Console.WriteLine(firstNumberNotEqualToNPrecedent);

            var contiguousSetThatSumTo = decryptor.GetContiguousSetThatSumTo(firstNumberNotEqualToNPrecedent);
            Console.WriteLine(contiguousSetThatSumTo.Min() + contiguousSetThatSumTo.Max());

            Console.ReadKey();
        }
    }
}