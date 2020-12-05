using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D4PassportProcessing
{
    public class Program
    {
        public const string InputTxt = "input.txt";

        public static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt);
            var passeports = GetPasseports(strings);

            var validPasseports = passeports.Count(x => x.ContainsRequiredFields());
            Console.WriteLine(validPasseports);
            var valid2Passeports = passeports.Count(x => x.IsValid());
            Console.WriteLine(valid2Passeports);
            Console.ReadKey();
        }

        public static List<Passeport> GetPasseports(IEnumerable<string> strings)
        {
            var passeports = new List<Passeport>();

            var passeport = new Passeport();
            passeports.Add(passeport);

            foreach (var s in strings)
                if (s.Length == 0)
                {
                    passeport = new Passeport();
                    passeports.Add(passeport);
                }
                else
                {
                    passeport.AddLine(s);
                }

            return passeports;
        }
    }
}