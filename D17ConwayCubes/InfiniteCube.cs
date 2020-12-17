using System;
using System.Collections.Generic;
using System.Linq;

namespace D17ConwayCubes
{
    public class InfiniteCube
    {
        private const char Active = '#';
        private const char Inactive = '.';
        private readonly Dictionary<Coords, char> _infiniteCube = new();

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

        private int MaxZ
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.Z) : 0; }
        }

        private int MaxY
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.Y) : 0; }
        }

        private int MaxX
        {
            get { return _infiniteCube.Keys.Any() ? _infiniteCube.Keys.Max(x => x.X) : 0; }
        }

        public char Get(int x, int y, int z)
        {
            return _infiniteCube.TryGetValue(new Coords(x, y, z), out var result) ? result : Inactive;
        }

        public IEnumerable<char> GetNeighbors(int x, int y, int z)
        {
            for (var i = x - 1; i <= x + 1; i++)
            for (var j = y - 1; j <= y + 1; j++)
            for (var k = z - 1; k <= z + 1; k++)
                if (!((i == x) & (j == y) & (k == z)))
                    yield return Get(i, j, k);
        }

        public void Set(int x, int y, int z, char value)
        {
            _infiniteCube[new Coords(x, y, z)] = value;
        }

        public void PrintSliceN(int n)
        {
            for (var i = MinX; i <= MaxX; i++)
            {
                for (var j = MinY; j <= MaxY; j++)
                    Console.Write(Get(i, j, n));

                Console.WriteLine();
            }
        }

        public InfiniteCube Clone()
        {
            var clone = new InfiniteCube();

            var maxX = MaxX;
            var maxY = MaxY;
            var maxZ = MaxZ;
            var minX = MinX;
            var minY = MinY;
            var minZ = MinZ;
            for (var i = minX; i <= maxX; i++)
            for (var j = minY; j <= maxY; j++)
            for (var k = minZ; k <= maxZ; k++)
                clone.Set(i, j, k, Get(i, j, k));

            return clone;
        }

        public void Copy(InfiniteCube copy)
        {
            var copyMaxX = copy.MaxX;
            var copyMaxY = copy.MaxY;
            var copyMaxZ = copy.MaxZ;
            var copyMinX = copy.MinX;
            var copyMinY = copy.MinY;
            var copyMinZ = copy.MinZ;
            for (var i = copyMinX; i <= copyMaxX; i++)
            for (var j = copyMinY; j <= copyMaxY; j++)
            for (var k = copyMinZ; k <= copyMaxZ; k++)
                Set(i, j, k, copy.Get(i, j, k));
        }

        public void ApplyRules()
        {
            var clone = Clone();
            var minX = MinX - 1;
            var minY = MinY - 1;
            var minZ = MinZ - 1;
            var maxX = MaxX + 1;
            var maxY = MaxY + 1;
            var maxZ = MaxZ + 1;
            for (var i = minX; i <= maxX; i++)
            for (var j = minY; j <= maxY; j++)
            for (var k = minZ; k <= maxZ; k++)
            {
                var point = Get(i, j, k);
                var activeNeighbors = GetNeighbors(i, j, k).Count(c => c == Active);
                if (point == Inactive && activeNeighbors == 3)
                    clone.Set(i, j, k, Active);
                else if (point == Active && (activeNeighbors == 2 || activeNeighbors == 3))
                    clone.Set(i, j, k, Active);
                else
                    clone.Set(i, j, k, Inactive);
            }

            Copy(clone);
        }

        public int GetNumberOfActiveCell()
        {
            return _infiniteCube.Values.Count(c => c == Active);
        }
    }
}