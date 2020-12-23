using System.Linq;

namespace D20JurassicJigsaw
{
    public static class CharArrayExtension
    {
        public static char[][] RotateClockWise(this char[][] grid)
        {
            var copy = grid.Select(x => x.ToArray()).ToArray();

            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
                copy[^(j + 1)][i] = grid[i][j];
            return copy;
        }

        public static char[][] FlipHorizontally(this char[][] grid)
        {
            var copy = grid.Select(x => x.ToArray()).ToArray();

            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
                copy[^(i + 1)][j] = grid[i][j];

            return copy;
        }
    }
}