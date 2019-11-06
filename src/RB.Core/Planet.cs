using Ardalis.GuardClauses;
using System.Collections.Generic;

namespace RB.Core
{
    public class Planet
    {
        private int width;
        private int height;
        private HashSet<(int x, int y)> scents;

        public Planet(int width, int height)
        {
            Guard.Against.OutOfRange(width, nameof(width), 0, 50);
            Guard.Against.OutOfRange(height, nameof(height), 0, 50);

            this.width = width;
            this.height = height;

            scents = new HashSet<(int x, int y)>();
        }

        public bool WithinWorld(int x, int y)
        {
            if (0 <= x && x <= width && 0 <= y && y <= height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void LeaveScent(int x, int y)
        {
            if (!scents.Contains((x, y)))
            {
                scents.Add((x, y));
            }
        }

        public bool CheckScent(int x, int y)
        {
            return scents.Contains((x, y));
        }
    }
}
