using System;
using System.Collections.Generic;
using System.Linq;

namespace D10AdapterArray
{
    public class Solver
    {
        private readonly IList<long> _adapters = new List<long>();

        private readonly Dictionary<long, long> _numberOfConnectionToThisAdapter = new Dictionary<long, long>();

        public Solver(IEnumerable<string> strings)
        {
            var enumerable = strings.ToList();
            foreach (var s in enumerable)
                _adapters.Add(long.Parse(s));
            _adapters = _adapters.OrderBy(x => x).ToList();
        }


        public (int x, int y) GetNumbersOfOneAndThreeGaps()
        {
            var one = 1; //connection from the outlet
            var three = 1; //connection to the device
            for (var i = 0; i < _adapters.Count; i++)
            {
                if (i + 1 == _adapters.Count) break;

                if (_adapters[i + 1] - _adapters[i] == 1) one++;
                else if (_adapters[i + 1] - _adapters[i] == 3) three++;
                else
                    throw new InvalidOperationException();
            }

            return (one, three);
        }


        public long GetNumberOfPathFromOutletToDevice()
        {
            _numberOfConnectionToThisAdapter[0] = 1; //only one connection from 0 to first adapter

            foreach (var adapter in _adapters)
            {
                _numberOfConnectionToThisAdapter[adapter] = 0;


                _numberOfConnectionToThisAdapter[adapter] += (_numberOfConnectionToThisAdapter.ContainsKey(adapter - 1) ? _numberOfConnectionToThisAdapter[adapter - 1] : 0) +
                                                             (_numberOfConnectionToThisAdapter.ContainsKey(adapter - 2) ? _numberOfConnectionToThisAdapter[adapter - 2] : 0) +
                                                             (_numberOfConnectionToThisAdapter.ContainsKey(adapter - 3) ? _numberOfConnectionToThisAdapter[adapter - 3] : 0);
            }

            return _numberOfConnectionToThisAdapter[_adapters.Max()];
        }
    }
}