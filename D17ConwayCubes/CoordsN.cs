using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D17ConwayCubes
{
    public readonly struct CoordsN
    {
        public IReadOnlyList<int> Coords { get; }

        public CoordsN(IReadOnlyList<int> coords)
        {
            Coords = coords;
        }

        public CoordsN(IEnumerable<int> coords)
        {
            Coords = coords.ToList();
        }

        public bool Equals(CoordsN other)
        {
            for (var index = 0; index < other.Coords.Count; index++)
                if (other.Coords[index] != Coords[index])
                    return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            return obj is CoordsN other && Equals(other);
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var coord in Coords)
                hash.Add(coord);
            return hash.ToHashCode();
        }

        public static bool operator ==(CoordsN left, CoordsN right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CoordsN left, CoordsN right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach (var coord in Coords)
            {
                builder.Append(coord);
                builder.Append(" ");
            }

            return builder.ToString();
        }
    }
}