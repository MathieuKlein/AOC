using System;
using System.Collections.Generic;
using System.Linq;

namespace D20JurassicJigsaw
{
    public class Tile
    {
        public Tile(IReadOnlyCollection<string> sb)
        {
            Number = long.Parse(sb.First().Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            Pixels = sb.Skip(1).Select(x => x.ToCharArray()).ToArray();
        }

        public char[][] Pixels { get; private set; }
        public long Number { get; }

        public Dictionary<Orientation, IEnumerable<char>> Borders
        {
            get
            {
                return new()
                {
                    { Orientation.North, Pixels[0] },
                    { Orientation.South, Pixels[^1] },
                    { Orientation.West, Pixels.Select(x => x[0]).ToArray() },
                    { Orientation.East, Pixels.Select(x => x[^1]).ToArray() }
                };
            }
        }

        public bool IsBorderMatch(Tile tile, Orientation orientation)
        {
            IEnumerable<char> otherBorder;
            switch (orientation)
            {
                case Orientation.East:
                    otherBorder = tile.Borders[Orientation.West];
                    break;
                case Orientation.South:
                    otherBorder = tile.Borders[Orientation.North];
                    break;
                case Orientation.North:
                    otherBorder = tile.Borders[Orientation.South];
                    break;
                case Orientation.West:
                    otherBorder = tile.Borders[Orientation.East];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orientation), orientation, null);
            }

            return Borders[orientation].SequenceEqual(otherBorder);
        }

        public void RotateClockWise()
        {
            Pixels = Pixels.RotateClockWise();
        }

        public void Flip()
        {
            Pixels = Pixels.FlipHorizontally();
        }

        public void Print()
        {
            foreach (var pixel in Pixels)
                Console.WriteLine(pixel);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}