using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RB.Core
{
    public class Simulation
    {
        private Planet mars;
        private IList<Robot> robots;

        public Simulation(string[] input)
        {
            var planetLine = input[0];
            var dimensions = planetLine.Split().Select(x => Convert.ToInt32(x)).ToArray();

            mars = new Planet(dimensions[0], dimensions[1]);

            var i = 1;
            robots = new List<Robot>();

            while (i < input.Length)
            {
                var robotLine1 = input[i].Split();

                var x = Convert.ToInt32(robotLine1[0]);
                var y = Convert.ToInt32(robotLine1[1]);
                var orientation = Convert.ToChar(robotLine1[2]);
                var instructions = input[i + 1];

                var robot = new Robot(x, y, orientation, instructions, mars);

                robots.Add(robot);

                i += 2;
            }
        }

        public string Run()
        {
            var sb = new StringBuilder();

            foreach (var robot in robots)
            {
                robot.Run();
                sb.AppendLine(robot.Status);
            }

            return sb.ToString();
        }
    }
}
