using System;
using System.Collections.Generic;
using System.Linq;

namespace D20JurassicJigsaw
{
    public class JigsawSolver
    {
        private static readonly char[][] Monster;
        private readonly HashSet<Match> _matchingBorders = new();
        private readonly int _numberOfTilePerDimension;
        private readonly List<Tile> _tiles = new();
        private readonly Dictionary<long, Tile> _tilesDict;
        private readonly int _widthOfATile;

        static JigsawSolver()
        {
            Monster = new char[3][];
            Monster[0] = "..................#.".ToCharArray();
            Monster[1] = "#....##....##....###".ToCharArray();
            Monster[2] = ".#..#..#..#..#..#...".ToCharArray();
        }

        public JigsawSolver(IEnumerable<string> strings)
        {
            var sb = new List<string>();
            foreach (var s in strings)
                if (s.Length == 0)
                {
                    _tiles.Add(new Tile(sb));
                    sb = new List<string>();
                }
                else
                {
                    sb.Add(s);
                    _widthOfATile = s.Length;
                }

            _numberOfTilePerDimension = (int) Math.Sqrt(_tiles.Count);

            _tilesDict = _tiles.ToDictionary(x => x.Number, x => x);
            foreach (var tile in _tiles)
                _matchingBorders.UnionWith(GetMatchingBorders(_tiles, tile));
        }


        public char[][] Solve()
        {
            var northWestCorner = GetNorthWestCorner();

            var arrayOfTile = new Tile[_numberOfTilePerDimension, _numberOfTilePerDimension];
            var tileRow = 0;
            arrayOfTile[0, tileRow] = _tilesDict[northWestCorner];
            while (tileRow < _numberOfTilePerDimension)
            {
                for (var i = 0; i < _numberOfTilePerDimension; i++)
                {
                    var currentTile = arrayOfTile[i, tileRow];
                    var newTile = GetTileAt(currentTile, Orientation.East);

                    if (newTile != null)
                        arrayOfTile[i + 1, tileRow] = newTile;

                    if (i + 1 == _numberOfTilePerDimension)
                    {
                        tileRow++;
                        if (tileRow < _numberOfTilePerDimension)
                        {
                            currentTile = arrayOfTile[0, tileRow - 1];

                            arrayOfTile[0, tileRow] = GetTileAt(currentTile, Orientation.South) ?? throw new InvalidOperationException();
                        }
                    }
                }
            }


            return CreateFinalGrid(arrayOfTile);
        }

        private long GetNorthWestCorner()
        {
            var corners = GetCorners();
            var matchingBordersGroupedByTile = _matchingBorders.ToLookup(x => x.Tile1, x => x);

            foreach (var x in corners)
                if (matchingBordersGroupedByTile[x].All(match => match.Tile1 == x && (match.Tile1Orientation == Orientation.South || match.Tile1Orientation == Orientation.East) ||
                                                                 match.Tile2 == x && (match.Tile2Orientation == Orientation.South || match.Tile2Orientation == Orientation.East)))
                {
                    return x;
                }

            throw new InvalidOperationException();
        }

        public int CountMonsters(char[][] finalGrid)
        {
            var waterCount = finalGrid.SelectMany(x => x).Count(c => c == '#');

            var solve = -1;
            for (var i = 0; i < 8; i++)
            {
                var count = JigsawSolver.CountMonsters(finalGrid);
                if (count > 0)
                {
                    solve = waterCount - count * 15;
                    break;
                }

                finalGrid = i == 4 ? finalGrid.FlipHorizontally() : finalGrid.RotateClockWise();
            }

            return solve;
        }

        private Tile? GetTileAt(Tile currentTile, Orientation orientation)
        {
            var borders = GetMatchingBorders(_tiles, currentTile);
            foreach (var match in borders.Where(x => x.Tile1 == currentTile.Number && x.Tile1Orientation == orientation))
            {
                var newTile = _tilesDict[match.Tile2];

                if (currentTile.IsBorderMatch(newTile, orientation))
                    return newTile;

                for (var i = 0; i < 8; i++)
                {
                    newTile.RotateClockWise();
                    if (currentTile.IsBorderMatch(newTile, orientation))
                        return newTile;
                    if (i == 3)
                        newTile.Flip();
                }
            }

            return null;
        }

        private char[][] CreateFinalGrid(Tile[,] arrayOfTile)
        {
            var skipFirstChar = 0 + 1;
            var skipLastChar = _widthOfATile - 1;
            var width = _numberOfTilePerDimension * _widthOfATile - _numberOfTilePerDimension * 2;
            var finalGrid = new char[width][];
            for (var i = 0; i < width; i++)
                finalGrid[i] = new char[width];

            for (var c = 0; c < _numberOfTilePerDimension; c++)
            for (var i = skipFirstChar; i < skipLastChar; i++)
            for (var r = 0; r < _numberOfTilePerDimension; r++)
            for (var j = skipFirstChar; j < skipLastChar; j++)
                finalGrid[c * 8 + i - 1][r * 8 + j - 1] = arrayOfTile[r, c].Pixels[i][j];
            return finalGrid;
        }

        public IEnumerable<long> GetCorners()
        {
            var matchingBordersGroupedByTile = _matchingBorders.ToLookup(x => x.Tile1, x => x);

            var corners = matchingBordersGroupedByTile.Where(x => x.Count() == 2).ToList();
            return corners.Select(x => x.Key);
        }

        private static int CountMonsters(IReadOnlyList<char[]> input)
        {
            var count = 0;
            for (var i = 0; i < input.Count - 20; i++)
            for (var j = 0; j < input[0].Length - 3; j++)
                if (IsAMonster(input, j, i))
                    count++;
            return count;
        }

        private static bool IsAMonster(IReadOnlyList<char[]> grid, int r, int c)
        {
            for (var i = 0; i < 20; i++)
            for (var j = 0; j < 3; j++)
                if (Monster[j][i] == '#' && grid[c + i][r + j] != '#')
                    return false;
            return true;
        }

        private static HashSet<Match> GetMatchingBorders(IEnumerable<Tile> tiles, Tile tile)
        {
            HashSet<Match> matchingNorthBorder = new();
            foreach (var tile2 in tiles.Except(new List<Tile> { tile }))
            foreach (var tileBorder in tile.Borders)
            foreach (var tile2Border in tile2.Borders)
            {
                if (tileBorder.Value.SequenceEqual(tile2Border.Value.Reverse()))
                {
                    matchingNorthBorder.Add(new Match(tile.Number, tileBorder.Key, tile2.Number, tile2Border.Key));
                    matchingNorthBorder.Add(new Match(tile2.Number, tile2Border.Key, tile.Number, tileBorder.Key));
                }

                if (tileBorder.Value.SequenceEqual(tile2Border.Value))
                {
                    matchingNorthBorder.Add(new Match(tile.Number, tileBorder.Key, tile2.Number, tile2Border.Key));
                    matchingNorthBorder.Add(new Match(tile2.Number, tile2Border.Key, tile.Number, tileBorder.Key));
                }
            }

            return matchingNorthBorder;
        }
    }
}