using System;

namespace D20JurassicJigsaw
{
    public class Match : IEquatable<Match>
    {
        public Match(long tile1, Orientation tile1Orientation, long tile2, Orientation tile2Orientation)
        {
            Tile1 = tile1;
            Tile1Orientation = tile1Orientation;
            Tile2 = tile2;
            Tile2Orientation = tile2Orientation;
        }

        public long Tile1 { get; }
        public Orientation Tile1Orientation { get; }
        public long Tile2 { get; }
        public Orientation Tile2Orientation { get; }

        public bool Equals(Match? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Tile1 == other.Tile1 && Tile1Orientation == other.Tile1Orientation && Tile2 == other.Tile2 && Tile2Orientation == other.Tile2Orientation;
        }

        public override string ToString()
        {
            return $"{Tile1} {Tile1Orientation} {Tile2} {Tile2Orientation}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Match) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Tile1, (int) Tile1Orientation, Tile2, (int) Tile2Orientation);
        }

        public static bool operator ==(Match? left, Match? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Match? left, Match? right)
        {
            return !Equals(left, right);
        }
    }
}