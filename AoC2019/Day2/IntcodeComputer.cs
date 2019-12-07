using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    /// <summary>
    ///     An Intcode computer.
    /// </summary>
    public class IntcodeComputer
    {
        private readonly int[] _initialHeap;
        private readonly int[] _heap;

        /// <summary>
        ///     Retrieves a read-only view of the computer's heap.
        /// </summary>
        public ReadOnlySpan<int> Heap => _heap;

        public IntcodeComputer(IEnumerable<int> initialPositions)
        {
            _initialHeap = initialPositions.ToArray();
            _heap = new int[_initialHeap.Length];
            Reset();
        }

        /// <summary>
        ///     Sets position 1 to <paramref name="noun"/>, and position 2 to <paramref name="verb"/>.
        /// </summary>
        /// <param name="noun">The noun to store in position 1.</param>
        /// <param name="verb">The verb to store in position 2.</param>
        public void SetInitialNounAndVerb(int noun, int verb)
        {
            Poke(1, noun);
            Poke(2, verb);
        }

        public void Reset()
        {
            _initialHeap.CopyTo(_heap, 0);
        }

        /// <summary>
        ///     Peeks heap location 0 for the result of a computation.
        /// </summary>
        /// <returns>
        ///     The contents of heap location 0.
        /// </returns>
        public int PeekResult()
        {
            return Peek(0);
        }

        private int Peek(Index position)
        {
            return _heap[position];
        }

        private void Poke(Index position, int newValue)
        {
            _heap[position] = newValue;
        }

        public void Run()
        {
            for (var pc = 0; pc < _heap.Length; pc += 4)
            {
                var opcode = Peek(pc);
                
                var operation = DecodeOpcode(pc, opcode);
                if (operation == null) return;
                
                var operand1 = PeekIndirect(pc + 1);
                var operand2 = PeekIndirect(pc + 2);

                PokeIndirect(pc + 3, operation(operand1, operand2));
            }
        }

        private int PeekIndirect(Index position)
        {
            return Peek(Peek(position));
        }

        private void PokeIndirect(Index position, int newValue)
        {
            Poke(Peek(position), newValue);
        }

        private Func<int, int, int>? DecodeOpcode(int position, int opcode)
        {
            return opcode switch
            {
                1 => (x, y) => x + y,
                2 => (x, y) => x * y,
                99 => null,
                _ => throw new BadOpcodeException(position, opcode)
            };
        }


    }
}
