using System;

namespace D17ConwayCubes
{
    public readonly struct Coords2
    {
        public Coords2(int x, int y, int z, int t)
        {
            X = x;
            Y = y;
            Z = z;
            T = t;
        }

        public int X { get; }
        public int Y { get; }
        public int Z { get; }
        public int T { get; }

        public bool Equals(Coords2 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && T == other.T;
        }

        public override bool Equals(object obj)
        {
            return obj is Coords2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z, T);
        }

        public static bool operator ==(Coords2 left, Coords2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coords2 left, Coords2 right)
        {
            return !left.Equals(right);
        }
    }
}