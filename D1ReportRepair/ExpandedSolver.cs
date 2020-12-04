using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportRepair
{
    public class ExpandedSolver
    {
        private readonly IReadOnlyList<int> _numbers;

        public ExpandedSolver(IReadOnlyList<int> numbers)
        {
            _numbers = numbers;
        }

        public int GetProductOfNNumbersWithSumEqualTo(int n, int sumToFind)
        {
            var twoUplet = GenerateNUplets(n).FirstOrDefault(t => t.Sum() == sumToFind) ?? Array.Empty<int>();
            return twoUplet.Aggregate((x, y) => x * y);
        }

        public IEnumerable<IEnumerable<int>> GenerateNUplets(int n)
        {
            var result = (IEnumerable<IEnumerable<int>>) new[] { Enumerable.Empty<int>() };
            for (var i = 0; i < n; i++)
                result = result.SelectMany(x => _numbers, (x, item) => x.Concat(new[] { item }));
            return result;
        }
    }
}