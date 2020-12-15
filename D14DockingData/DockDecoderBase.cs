using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace D14DockingData
{
    public abstract class DockDecoderBase
    {
        private static readonly Regex RegexMem = new Regex("^mem\\[(\\d+)\\] = (\\d+)", RegexOptions.Compiled);
        private static readonly Regex RegexMask = new Regex("^mask = ([X0-9]+)", RegexOptions.Compiled);
        private readonly List<Sequence> _sequences = new List<Sequence>();
        public const char X = 'X';
        public const char One = '1';

        protected DockDecoderBase(IEnumerable<string> strings)
        {
            Sequence? sequence = null;
            foreach (var s in strings)
                if (s.StartsWith("mask"))
                {
                    sequence = new Sequence(RegexMask.Split(s)[1]);
                    _sequences.Add(sequence);
                }
                else if (s.StartsWith("mem"))
                {
                    var split = RegexMem.Split(s);
                    sequence?.Memory.Add(int.Parse(split[1]), long.Parse(split[2]));
                }
        }

        public IReadOnlyList<Sequence> Sequences => _sequences;

        public abstract IReadOnlyDictionary<long, long> Decode();
    }
}