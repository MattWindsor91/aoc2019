using System.Collections.Generic;

namespace Day2
{
    /// <summary>
    ///     Code for running part 1 of the day 2 solution.
    /// </summary>
    public static class Part1
    {
        public static int Run(IEnumerable<int> initialPositions)
        {
            var computer = new IntcodeComputer(initialPositions);

            // 1202 program alarm
            computer.SetInitialNounAndVerb(12, 2);

            computer.Run();
            return computer.PeekResult();
        }
    }
}
