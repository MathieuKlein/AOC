using System;
using System.Collections.Generic;
using System.Text;

namespace D14DockingData
{
    public class DockDecoderV2 : DockDecoderBase
    {
        public DockDecoderV2(IEnumerable<string> strings) : base(strings)
        {
        }

        public override IReadOnlyDictionary<long, long> Decode()
        {
            var memory = new Dictionary<long, long>();

            foreach (var sequence in Sequences)
            foreach (var (key, value) in sequence.Memory)
            {
                var unenumeratedAdresses = GetUnenumeratedAdresses(key, sequence);
                var addresses = Enumerate(unenumeratedAdresses);

                foreach (var address in addresses)
                {
                    memory[Convert.ToInt64(address, 2)] = value;
                }
            }

            return memory;
        }

        private static string GetUnenumeratedAdresses(long key, Sequence sequence)
        {
            var binary36 = Convert.ToString(key, 2).PadLeft(36, '0');
            var builder = new StringBuilder();
            for (var i = 0; i < binary36.Length; i++)
            {
                var c = binary36[i];
                if (sequence.Mask[i] == X)
                    c = X;
                else if (sequence.Mask[i] == One)
                    c = One;
                builder.Append(c);
            }

            var unenumeratedAdresses = builder.ToString();
            return unenumeratedAdresses;
        }

        private IEnumerable<string> Enumerate(string unenumeratedAdresses)
        {
            var part = unenumeratedAdresses.Split(X, 2);
            if (part.Length == 1)
                yield return unenumeratedAdresses;
            else
            {
                foreach (var lastPart in Enumerate(part[1]))
                {
                    yield return $"{part[0]}0{lastPart}";
                    yield return $"{part[0]}1{lastPart}";
                }
            }
        }
    }
}