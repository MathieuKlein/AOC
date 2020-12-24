using System;

namespace D24LobbyLayout
{
    public class Tile : IEquatable<Tile>
    {
        public Tile(decimal ns, decimal ew)
        {
            NS = ns;
            EW = ew;
        }

        public Tile()
        {
        }

        public decimal NS { get; }
        public decimal EW { get; }
        public bool IsBlack { get; private set; }

        public bool Equals(Tile? other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return NS == other.NS && EW == other.EW;
        }

        public void FlipTile()
        {
            IsBlack = !IsBlack;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Tile) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NS, EW);
        }

        public static bool operator ==(Tile left, Tile right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Tile? left, Tile? right)
        {
            return !Equals(left, right);
        }
    }
}