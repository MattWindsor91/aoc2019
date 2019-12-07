using System;

namespace Day2
{
    /// <summary>
    ///     Exception raised if a bad opcode is executed.
    /// </summary>
    public class BadOpcodeException : Exception
    {
        public BadOpcodeException(int position, int opcode) : base($"Invalid opcode: {opcode} (at {position})")
        {
        }
    }
}
