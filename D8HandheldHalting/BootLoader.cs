using System;
using System.Collections.Generic;
using System.Linq;

namespace D8HandheldHalting
{
    public class BootLoader
    {
        private readonly List<Instruction> _instructions = new List<Instruction>();

        public BootLoader(IEnumerable<string> instructions)
        {
            foreach (var instruction in instructions)
            {
                var split = instruction.Split(" ");
                _instructions.Add(new Instruction(split[0], split[1]));
            }
        }

        public int GetLastValueAccumulatorWhenFirstRoundEnd()
        {
            return new BootRunner(_instructions).Boot();
        }

        public int GetLastValueAccumulatorWhenTerminates()
        {
            var allJumps = _instructions.Where(x => x.Operation == Operation.Jmp);

            foreach (var t in allJumps)
            {
                t.Operation = Operation.Nop;

                var bootRunner = new BootRunner(_instructions);
                var accumulator = bootRunner.Boot();

                if (bootRunner.IndexIsAtEnd)
                    return accumulator;

                t.Operation = Operation.Jmp;
            }

            throw new InvalidOperationException("No non circular sequence found.");
        }
    }
}