using System;
using System.Collections.Generic;
using System.Text;

namespace Day2
{
    /// <summary>
    ///     Code for running part 2 of the day 2 solution.
    /// </summary>
    public static class Part2
    {
        public static int Run(IEnumerable<int> initialPositions)
        {
            var computer = new IntcodeComputer(initialPositions);

            for (var noun = 0; noun < 100; noun++)
            {
                for (var verb = 0; verb < 100; verb++)
                {
                    computer.SetInitialNounAndVerb(noun, verb);
                    computer.Run();
                    if (computer.PeekResult() == 19690720) return 100 * noun + verb;
                    computer.Reset();
                }
            }

            throw new IndexOutOfRangeException("ran out of nouns and verbs to try");
        }
    }
}
