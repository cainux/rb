using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace RB.Core
{
    public class Robot
    {
        private int x;
        private int y;
        private char orientation;
        private string instructions;
        private Planet planet;
        private bool isLost;

        private Dictionary<char, Action> commandHandlers;

        public Robot(int x, int y, char orientation, string instructions, Planet planet)
        {
            Guard.Against.OutOfRange(x, nameof(x), 0, 50);
            Guard.Against.OutOfRange(y, nameof(y), 0, 50);

            if (instructions.Length > 100)
                throw new ArgumentException("Instructions are limited to 100 characters in length", nameof(instructions));

            this.x = x;
            this.y = y;
            this.orientation = orientation;
            this.instructions = instructions;
            this.planet = planet;

            isLost = false;

            commandHandlers = new Dictionary<char, Action>
            {
                { 'F', Forward },
                { 'R', Right },
                { 'L', Left }
            };
        }

        private void Forward()
        {
            var nextPosition = MovementHelper.GetNextPosition[orientation](x, y);

            if (planet.WithinWorld(nextPosition.x, nextPosition.y))
            {
                x = nextPosition.x;
                y = nextPosition.y;
            }
            else
            {
                if (!planet.CheckScent(x, y))
                {
                    isLost = true;
                    planet.LeaveScent(x, y);
                }
            }
        }

        private void Right()
        {
            var nextOrientation = MovementHelper.NextRightOrientations[orientation];

            orientation = nextOrientation;
        }

        private void Left()
        {
            var nextOrientation = MovementHelper.NextLeftOrientations[orientation];

            orientation = nextOrientation;
        }

        public string Run()
        {
            foreach (var i in instructions)
            {
                commandHandlers[i]();

                if (isLost)
                {
                    break;
                }
            }

            return $"{x} {y} {orientation}" + (isLost ? " LOST" : string.Empty);
        }

        private static class MovementHelper
        {
            public static readonly Dictionary<char, Func<int, int, (int x, int y)>> GetNextPosition = new Dictionary<char, Func<int, int, (int, int)>>
            {
                { 'N', (x, y) => (x, y + 1) },
                { 'E', (x, y) => (x + 1, y) },
                { 'S', (x, y) => (x, y - 1) },
                { 'W', (x, y) => (x - 1, y) }
            };

            public static readonly Dictionary<char, char> NextRightOrientations = new Dictionary<char, char>
            {
                { 'N', 'E' },
                { 'E', 'S' },
                { 'S', 'W' },
                { 'W', 'N' }
            };

            public static readonly Dictionary<char, char> NextLeftOrientations = new Dictionary<char, char>
            {
                { 'N', 'W' },
                { 'E', 'N' },
                { 'S', 'E' },
                { 'W', 'S' }
            };
        }
    }
}
