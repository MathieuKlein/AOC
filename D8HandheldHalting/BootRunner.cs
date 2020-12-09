using System;
using System.Collections.Generic;

namespace D8HandheldHalting
{
    public class BootRunner
    {
        private readonly IReadOnlyList<Instruction> _instructions;
        private readonly HashSet<int> _visitedInstructions = new HashSet<int>();
        private int _accumulator;
        private int _index;


        public BootRunner(IReadOnlyList<Instruction> instructions)
        {
            _instructions = instructions;
        }

        public bool IndexIsAtEnd => _index >= _instructions.Count;

        public int Boot()
        {
            foreach (var _ in _instructions) //Au maximum on parcourra tous les instructions avant d'executer une instruction deux fois.
            {
                _visitedInstructions.Add(_index);

                if (_instructions[_index].Operation == Operation.Acc)
                    Accumulate(_instructions[_index].Argument);
                else if (_instructions[_index].Operation == Operation.Jmp)
                    Jump(_instructions[_index].Argument);
                else
                    GoToNextInstruction();

                if (_visitedInstructions.Contains(_index) || IndexIsAtEnd)
                    return _accumulator;
            }

            throw new InvalidOperationException("Cannot execute instruction twice.");
        }

        private void Accumulate(int argument)
        {
            _accumulator += argument;
            _index++;
        }

        private void Jump(int argument)
        {
            _index += argument;
        }

        private void GoToNextInstruction()
        {
            _index++;
        }
    }
}