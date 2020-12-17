using System;
using System.Collections.Generic;
using System.Linq;

namespace D17ConwayCubes
{
    public class InfiniteHyperCube
    {
        private const char Active = '#';
        private const char Inactive = '.';
        private readonly Dictionary<Coords2, char> _infiniteCube = new();

        private int MinZ
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Min(x => x.Z) : 0; }
        }

        private int MinY
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Min(x => x.Y) : 0; }
        }

        private int MinX
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Min(x => x.X) : 0; }
        }

        private int MinT
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Min(x => x.T) : 0; }
        }

        private int MaxZ
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.Z) : 0; }
        }

        private int MaxT
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.T) : 0; }
        }

        private int MaxY
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.Y) : 0; }
        }

        private int MaxX
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.X) : 0; }
        }

        public char Get(int x, int y, int z, int t)
        {
            return _infiniteCube.TryGetValue(new Coords2(x, y, z, t), out var result) ? result : Inactive;
        }

        public IEnumerable<char> GetNeighbors(int x, int y, int z, int t)
        {
            for (var i = x - 1; i <= x + 1; i++)
            for (var j = y - 1; j <= y + 1; j++)
            for (var k = z - 1; k <= z + 1; k++)
            for (var l = t - 1; l <= t + 1; l++)
                if (!((i == x) & (j == y) & (k == z) & (l == t)))
                    yield return Get(i, j, k, l);
        }

        public void Set(int x, int y, int z, int t, char value)
        {
            _infiniteCube[new Coords2(x, y, z, t)] = value;
        }

        public void PrintSliceN(int t, int n)
        {
            for (var i = MinX; i <= MaxX; i++)
            {
                for (var j = MinY; j <= MaxY; j++)
                    Console.Write(Get(i, j, t, n));

                Console.WriteLine();
            }
        }

        public InfiniteHyperCube Clone()
        {
            var clone = new InfiniteHyperCube();

            var maxX = MaxX;
            var maxY = MaxY;
            var maxZ = MaxZ;
            var maxT = MaxT;
            var minX = MinX;
            var minY = MinY;
            var minZ = MinZ;
            var minT = MinT;
            for (var i = minX; i <= maxX; i++)
            for (var j = minY; j <= maxY; j++)
            for (var k = minZ; k <= maxZ; k++)
            for (var l = minT; k <= maxT; k++)
                clone.Set(i, j, k, l, Get(i, j, k, l));

            return clone;
        }

        public void Copy(InfiniteHyperCube copy)
        {
            var copyMaxX = copy.MaxX;
            var copyMaxY = copy.MaxY;
            var copyMaxZ = copy.MaxZ;
            var copyMaxT = copy.MaxT;
            var copyMinX = copy.MinX;
            var copyMinY = copy.MinY;
            var copyMinZ = copy.MinZ;
            var copyMinT = copy.MinT;
            for (var i = copyMinX; i <= copyMaxX; i++)
            for (var j = copyMinY; j <= copyMaxY; j++)
            for (var k = copyMinZ; k <= copyMaxZ; k++)
            for (var l = copyMinT; l <= copyMaxT; l++)
                Set(i, j, k, l, copy.Get(i, j, k, l));
        }

        public void ApplyRules()
        {
            var clone = Clone();
            var minX = MinX - 1;
            var minY = MinY - 1;
            var minZ = MinZ - 1;
            var minT = MinT - 1;
            var maxX = MaxX + 1;
            var maxY = MaxY + 1;
            var maxZ = MaxZ + 1;
            var maxT = MaxT + 1;
            for (var i = minX; i <= maxX; i++)
            for (var j = minY; j <= maxY; j++)
            for (var k = minZ; k <= maxZ; k++)
            for (var l = minT; l <= maxT; l++)
            {
                var point = Get(i, j, k, l);
                var activeNeighbors = GetNeighbors(i, j, k, l).Count(c => c == Active);
                if (point == Inactive && activeNeighbors == 3)
                    clone.Set(i, j, k, l, Active);
                else if (point == Active && (activeNeighbors == 2 || activeNeighbors == 3))
                    clone.Set(i, j, k, l, Active);
                else
                    clone.Set(i, j, k, l, Inactive);
            }

            Copy(clone);
        }

        public int GetNumberOfActiveCell()
        {
            return _infiniteCube.Values.Count(c => c == Active);
        }
    }
}