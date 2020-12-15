using System;
using System.Collections.Generic;
using System.Text;

namespace D14DockingData
{
    public class DockDecoderV1 : DockDecoderBase
    {
        private const char Zero = '0';

        public DockDecoderV1(IEnumerable<string> strings) : base(strings)
        {
        }

        public override IReadOnlyDictionary<long, long> Decode()
        {
            var memory = new Dictionary<long, long>();

            foreach (var sequence in Sequences)
            foreach (var (key, value) in sequence.Memory)
            {
                var binary36 = Convert.ToString(value, 2).PadLeft(36, Zero);
                var builder = new StringBuilder();
                for (var i = 0; i < binary36.Length; i++)
                {
                    var c = binary36[i];
                    if (sequence.Mask[i] == Zero)
                        c = Zero;
                    else if (sequence.Mask[i] == One)
                        c = One;
                    builder.Append(c);
                }

                memory[key] = Convert.ToInt64(builder.ToString(), 2);
            }

            return memory;
        }
    }
}