using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportRepair
{
    public class ExpandedSolver
    {
        private readonly IEnumerable<long> _numbers;

        public ExpandedSolver(IEnumerable<long> numbers)
        {
            _numbers = numbers.OrderBy(x => x);
        }

        public IEnumerable<long> GetNNumbersWithSumEqualTo(long n, long sumToFind)
        {
            return GenerateNUplets(n).FirstOrDefault(t => t.Sum() == sumToFind) ?? Array.Empty<long>();
        }

        public IEnumerable<IEnumerable<long>> GenerateNUplets(long n)
        {
            var result = (IEnumerable<IEnumerable<long>>) new[] { Enumerable.Empty<long>() };
            for (var i = 0; i < n; i++)
                result = result.SelectMany(x => _numbers, (x, item) => x.Concat(new[] { item }));
            return result;
        }
    }
}