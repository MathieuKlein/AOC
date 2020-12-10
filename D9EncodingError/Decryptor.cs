using System;
using System.Collections.Generic;
using System.Linq;
using ReportRepair;

namespace D9EncodingError
{
    public class Decryptor
    {
        private readonly IList<long> _numbers = new List<long>();

        public Decryptor(IEnumerable<string> strings)
        {
            foreach (var s in strings)
                _numbers.Add(long.Parse(s));
        }

        public IList<long> GetContiguousSetThatSumTo(long sumExpected)
        {
            for (var i = 0; i < _numbers.Count; i++)
            for (var j = 0; j < _numbers.Count; j++)
            {
                var numberFromIToIPlusJ = _numbers.Skip(i).Take(j).ToList();
                var sum = numberFromIToIPlusJ.Sum();
                if (sum > sumExpected)
                    break;
                if (sum == sumExpected)
                    return numberFromIToIPlusJ;
            }

            throw new InvalidOperationException("No such set.");
        }

        public long GetFirstNumberNotEqualToNPrecedent(int key)
        {
            for (var i = key; i < _numbers.Count; i++)
            {
                var lastNNumbers = _numbers.Skip(i - key).Take(key);

                var twoNumbersWithSumEqualTo2 = new ExpandedSolver(lastNNumbers).GetNNumbersWithSumEqualTo(2, _numbers[i]);

                if (!twoNumbersWithSumEqualTo2.Any())
                    return _numbers[i];
            }

            throw new InvalidOperationException("No such number");
        }
    }
}