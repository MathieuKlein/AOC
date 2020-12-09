using System;

namespace D8HandheldHalting
{
    public enum Operation
    {
        Acc,
        Jmp,
        Nop
    }

    public class Instruction
    {
        public Instruction(string operation, string argument)
        {
            Operation = Enum.Parse<Operation>(operation, true);
            Argument = int.Parse(argument);
        }

        public Operation Operation { get; set; }
        public int Argument { get; set; }
    }
}