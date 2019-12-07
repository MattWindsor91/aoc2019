using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        private readonly string _inputFile;

        public Program(string inputFile)
        {
            _inputFile = inputFile;
        }

        static void Main(string[] args)
        {
            new Program(args[0]).Run();
        }

        public void Run()
        {
            var positions = GetInputPositions().ToArray();

            Console.Out.WriteLine($"Part 1: {Part1.Run(positions)}");
            Console.Out.WriteLine($"Part 2: {Part2.Run(positions)}");
        }

        private IEnumerable<int> GetInputPositions()
        {
            var contents = ReadInput();
            var positionStrings = contents.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
            var positions = from positionString in positionStrings
                select int.Parse(positionString, NumberStyles.None);
            return positions;
        }

        private string ReadInput()
        {
            using var file = File.OpenRead(_inputFile);
            using var reader = new StreamReader(file);
            var contents = reader.ReadToEnd();
            return contents;
        }
    }
}
