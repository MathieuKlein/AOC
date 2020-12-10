using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ReportRepair
{
    public class NaiveSolver
    {
        private readonly IList<long> _numbers;

        public NaiveSolver(IEnumerable<long> numbers)
        {
            _numbers = numbers.OrderBy(x => x).ToList();
        }

        public (long n1, long n2) Get2NumbersWithSumEqualTo(long toFind)
        {
            var sumToFind = toFind;
            for (var index = 0; index < _numbers.Count; index++)
            {
                var n1 = _numbers[index];
                foreach (var n2 in _numbers.Skip(index))
                {
                    var sum = n2 + n1;
                    if (sum > sumToFind)
                        break;
                    Debug.WriteLine($"{n1} + {n2} = {sum}");
                    if (sum != sumToFind)
                        continue;
                    return (n1, n2);
                }
            }

            return default;
        }

        public (long n1, long n2, long n3) Get3NumbersWithSumEqualTo(long sumToFind)
        {
            for (var i = 0; i < _numbers.Count; i++)
            {
                var n1 = _numbers[i];
                for (var j = i; j < _numbers.Count; j++)
                {
                    var n2 = _numbers[j];
                    var sum = n2 + n1;
                    if (sum > sumToFind)
                        break;
                    for (var k = j; k < _numbers.Count; k++)
                    {
                        Debug.WriteLine($"{i} {j} {k}");
                        var n3 = _numbers[k];
                        sum = n1 + n2 + n3;
                        if (sum > sumToFind)
                            break;
                        Debug.WriteLine($"{n1} + {n2} + {n3} = {sum}");
                        if (sum != sumToFind)
                            continue;
                        return (n1, n2, n3);
                    }
                }
            }

            return default;
        }
    }
}