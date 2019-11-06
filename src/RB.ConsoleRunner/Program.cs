using RB.Core;
using System;
using System.IO;

namespace RB.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = "input.txt";

            if (args != null && args.Length > 0)
            {
                inputFile = args[0];
            }

            var input = File.ReadAllLines(inputFile);

            Console.WriteLine("--- INPUT ---");

            foreach (var line in input)
            {
                Console.WriteLine(line);
            }

            var simulation = new Simulation(input);
            var result = simulation.Run();

            Console.WriteLine(string.Empty);
            Console.WriteLine("--- OUTPUT ---");

            Console.Write(result);
        }
    }
}
