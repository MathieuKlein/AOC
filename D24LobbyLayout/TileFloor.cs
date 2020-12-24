using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace D24LobbyLayout
{
    public class TileFloor
    {
        private const string Se = "se";
        private const string Nw = "nw";
        private const string Sw = "sw";
        private const string Ne = "ne";
        private const string E = "e";
        private const string W = "w";
        private static readonly Tile OutTile = new();
        private readonly HashSet<Tile> _floor = new();
        public int NumberOfBlackTiles => _floor.Count(x => x.IsBlack);

        public void FlipTile(string s)
        {
            decimal se = Regex.Matches(s, Se).Count;
            var nw = Regex.Matches(s, Nw).Count;
            s = s.Replace(Se, string.Empty);
            s = s.Replace(Nw, string.Empty);
            var sw = Regex.Matches(s, Sw).Count;
            var ne = Regex.Matches(s, Ne).Count;
            s = s.Replace(Sw, string.Empty);
            s = s.Replace(Ne, string.Empty);
            var e = Regex.Matches(s, E).Count;
            var w = Regex.Matches(s, W).Count;
            var ns = ne + nw - se - sw;
            var ew = e - w + (se + ne - nw - sw) / 2M;
            var value = new Tile(ns, ew);

            if (_floor.TryGetValue(value, out var actualValue))
            {
                actualValue.FlipTile();
            }
            else
            {
                value.FlipTile();
                _floor.Add(value);
            }
        }

        public void CompleteFloor()
        {
            var maxEast = _floor.Max(x => x.EW);
            var minWest = _floor.Min(x => x.EW);
            var maxNorth = _floor.Max(x => x.NS);
            var minSouth = _floor.Min(x => x.NS);
            for (var i = (int) minSouth - 1; i <= maxNorth + 1; i++)
            for (var j = (int) minWest - 1; j <= maxEast + 1; j++)
                _floor.Add(new Tile(i, (decimal) (j + i % 2 * 0.5)));
        }

        public IEnumerable<Tile> GetNeighbors(decimal i, decimal j)
        {
            Tile? actualValue;
            yield return _floor.TryGetValue(new Tile(i, j - 1), out actualValue) ? actualValue : OutTile;
            yield return _floor.TryGetValue(new Tile(i, j + 1), out actualValue) ? actualValue : OutTile;
            yield return _floor.TryGetValue(new Tile(i - 1, j - 0.5M), out actualValue) ? actualValue : OutTile;
            yield return _floor.TryGetValue(new Tile(i - 1, j + 0.5M), out actualValue) ? actualValue : OutTile;
            yield return _floor.TryGetValue(new Tile(i + 1, j - 0.5M), out actualValue) ? actualValue : OutTile;
            yield return _floor.TryGetValue(new Tile(i + 1, j + 0.5M), out actualValue) ? actualValue : OutTile;
        }

        public void DailyFlip()
        {
            var tilesToFlip = new List<Tile>();

            foreach (var tile in _floor)
            {
                var blackN = GetNeighbors(tile.NS, tile.EW).Count(x => x.IsBlack);

                if (tile.IsBlack && (blackN == 0 || blackN > 2)
                    || !tile.IsBlack && blackN == 2)
                    tilesToFlip.Add(tile);
            }

            foreach (var tile in tilesToFlip)
                tile.FlipTile();
        }
    }
}