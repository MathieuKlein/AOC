using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D12
{
    internal class Program
    {
        public const string InputTxt = "input.txt";
        private const char North = 'N';
        private const char South = 'S';
        private const char East = 'E';
        private const char West = 'W';
        private const char Forward = 'F';
        private const char Left = 'L';
        private const char Right = 'R';

        private static void Main(string[] args)
        {
            var strings = File.ReadLines(InputTxt).ToList();

            var directions = new List<char> { North, East, South, West };

            var direction = East;
            var east = 0;
            var north = 0;
            foreach (var s in strings)
            {
                var letter = s.First();
                var arg = int.Parse(s.Substring(1));
                switch (letter)
                {
                    case North:
                        north += arg;
                        break;
                    case South:
                        north -= arg;
                        break;
                    case East:
                        east += arg;
                        break;
                    case West:
                        east -= arg;
                        break;
                    case Forward:
                        switch (direction)
                        {
                            case North:
                                north += arg;
                                break;
                            case South:
                                north -= arg;
                                break;
                            case East:
                                east += arg;
                                break;
                            case West:
                                east -= arg;
                                break;
                        }

                        break;
                    case Left:
                    {
                        var indexOf = (directions.IndexOf(direction) - arg / 90) % 4;
                        if (indexOf < 0)
                            indexOf += 4;
                        direction = directions[indexOf];
                        break;
                    }
                    case Right:
                    {
                        var indexOf = (directions.IndexOf(direction) + arg / 90) % 4;
                        if (indexOf < 0)
                            indexOf += 4;
                        direction = directions[indexOf];
                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(east) + Math.Abs(north));

            east = 0;
            north = 0;
            var weast = 10;
            var wnorth = 1;
            foreach (var s in strings)
            {
                var letter = s.First();
                var arg = int.Parse(s.Substring(1));
                switch (letter)
                {
                    case North:
                        wnorth += arg;
                        break;
                    case South:
                        wnorth -= arg;
                        break;
                    case East:
                        weast += arg;
                        break;
                    case West:
                        weast -= arg;
                        break;
                    case Forward:
                    {
                        for (var i = 0; i < arg; i++)
                        {
                            north += wnorth;
                            east += weast;
                        }

                        break;
                    }
                    case Left:
                    {
                        for (var i = 0; i < arg / 90; i++)
                        {
                            var temp = weast;
                            weast = -wnorth;
                            wnorth = temp;
                        }

                        break;
                    }
                    case Right:
                    {
                        for (var i = 0; i < arg / 90; i++)
                        {
                            var temp = weast;
                            weast = wnorth;
                            wnorth = -temp;
                        }

                        break;
                    }
                }
            }

            Console.WriteLine(Math.Abs(east) + Math.Abs(north));

            Console.ReadKey();
        }
    }
}