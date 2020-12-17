using System.Collections.Generic;
using System.Linq;

namespace D17ConwayCubes
{
    public class InfiniteHyperCubeN
    {
        private const char Active = '#';
        private const char Inactive = '.';
        private readonly Dictionary<CoordsN, char> _infiniteCube = new();

        public List<int> Mins
        {
            get { return _infiniteCube.Keys.First().Coords.Select((t, i) => _infiniteCube.Keys.Select(x => x.Coords[i]).Min()).ToList(); }
        }

        public List<int> Maxes
        {
            get { return _infiniteCube.Keys.First().Coords.Select((t, i) => _infiniteCube.Keys.Select(x => x.Coords[i]).Max()).ToList(); }
        }

        public char Get(params int[] coords)
        {
            return Get(new CoordsN(coords));
        }

        public void Set(char value, params int[] coords)
        {
            _infiniteCube[new CoordsN(coords)] = value;
        }

        public int GetNumberOfActiveCell()
        {
            return _infiniteCube.Values.Count(c => c == Active);
        }

        public void ApplyRules()
        {
            var clone = Clone();

            foreach (var nUplet in GenerateNUplets(Mins.Select(x => x - 1).ToList(), Maxes.Select(x => x + 1).ToList()))
            {
                var coords = new CoordsN(nUplet);

                var point = Get(coords);
                var activeNeighbors = GetNeighbors(coords).Count(c => c == Active);
                if (point == Inactive && activeNeighbors == 3)
                    clone.Set(Active, coords);
                else if (point == Active && (activeNeighbors == 2 || activeNeighbors == 3))
                    clone.Set(Active, coords);
                else
                    clone.Set(Inactive, coords);
            }

            Copy(clone);
        }

        private IEnumerable<char> GetNeighbors(CoordsN coords)
        {
            var mins = new List<int>();
            var maxes = new List<int>();
            for (var i = 0; i < _infiniteCube.Keys.First().Coords.Count; i++)
            {
                mins.Add(coords.Coords[i] - 1);
                maxes.Add(coords.Coords[i] + 1);
            }

            var all = GenerateNUplets(mins, maxes);

            foreach (var nUplet in all)
            {
                var coordsNeighbor = new CoordsN(nUplet);
                if (!coordsNeighbor.Equals(coords))
                    yield return Get(coordsNeighbor);
            }
        }

        private char Get(CoordsN coords)
        {
            return _infiniteCube.TryGetValue(coords, out var result) ? result : Inactive;
        }

        private void Set(char value, CoordsN coords)
        {
            _infiniteCube[coords] = value;
        }

        private InfiniteHyperCubeN Clone()
        {
            var clone = new InfiniteHyperCubeN();

            foreach (var nUplet in GenerateNUplets(Mins, Maxes))
            {
                var coords = new CoordsN(nUplet);
                clone.Set(Get(coords), coords);
            }

            return clone;
        }

        private void Copy(InfiniteHyperCubeN copy)
        {
            foreach (var nUplet in GenerateNUplets(copy.Mins, copy.Maxes))
                Set(copy.Get(nUplet.ToArray()), new CoordsN(nUplet));
        }

        private IEnumerable<IEnumerable<int>> GenerateNUplets(IReadOnlyList<int> mins, IReadOnlyList<int> maxes)
        {
            var sequences = new List<List<int>>();

            for (var i = 0; i < mins.Count; i++)
            {
                var min = mins[i];
                var max = maxes[i];
                var sequence = new List<int>();
                for (var j = min; j <= max; j++)
                    sequence.Add(j);
                sequences.Add(sequence);
            }

            return CartesianProduct(sequences);
        }

        private IEnumerable<IEnumerable<int>> CartesianProduct(IEnumerable<IEnumerable<int>> sequences)
        {
            IEnumerable<IEnumerable<int>> emptyProduct = new[] { Enumerable.Empty<int>() };
            IEnumerable<IEnumerable<int>> result = emptyProduct;
            foreach (var sequence in sequences)
                result = result.SelectMany(_ => sequence, (newSequence, n) => newSequence.Concat(new[] { n }));
            return result;
        }
    }
}