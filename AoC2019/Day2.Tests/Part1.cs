using System;
using System.Collections.Generic;
using Xunit;

namespace Day2.Tests
{
    /// <summary>
    ///     Unit tests for the part 1 examples.
    /// </summary>
    public class Part1
    {
        public static TheoryData<int[], int[]> ProgramStateData = new TheoryData<int[], int[]>
        {
            {new[] {1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50}, new[] {3500, 9, 10, 70, 2, 3, 11, 0, 99, 30, 40, 50}},
            {new[] {1, 0, 0, 0, 99}, new[] {2, 0, 0, 0, 99}},
            {new[] {2, 3, 0, 3, 99}, new[] {2, 3, 0, 6, 99}},
            {new[] {2, 4, 4, 5, 99, 0}, new[] {2, 4, 4, 5, 99, 9801}},
            {new[] {1, 1, 1, 4, 99, 5, 6, 0, 99}, new[] {30, 1, 1, 4, 2, 5, 6, 0, 99}}
        };

        [Theory]
        [MemberData(nameof(ProgramStateData))]
        public void TestInputAndOutputPairs(int[] input, int[] expectedOutput)
        {
            var computer = new IntcodeComputer(input);
            computer.Run();
            Assert.Equal(expectedOutput, computer.Heap.ToArray());
        }
    }
}
