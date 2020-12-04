using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ReportRepair
{
    public class NaiveSolver
    {
        private readonly IReadOnlyList<int> _numbers;

        public NaiveSolver(IReadOnlyList<int> numbers)
        {
            _numbers = numbers;
        }

        public (int n1, int n2) Get2NumbersWithSumEqualTo(int toFind)
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

        public (int n1, int n2, int n3) Get3NumbersWithSumEqualTo(int sumToFind)
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