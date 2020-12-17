using System.Collections.Generic;

namespace D17ConwayCubes
{
    public readonly struct Coords
    {
        public Coords(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }

        public int Y { get; }

        public int Z { get; }
    }
}