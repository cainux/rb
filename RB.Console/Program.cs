using RB.Core;
using System.IO;

namespace RB.Console
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

            System.Console.WriteLine("--- INPUT ---");

            foreach (var line in input)
            {
                System.Console.WriteLine(line);
            }

            var simulation = new Simulation(input);
            var result = simulation.Run();

            System.Console.WriteLine("--- OUTPUT ---");

            System.Console.Write(result);
        }
    }
}
