using System;

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

        public Robot(int x, int y, char orientation, string instructions, Planet planet)
        {
            this.x = x;
            this.y = y;
            this.orientation = orientation;
            this.instructions = instructions;
            this.planet = planet;
            this.isLost = false;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public string Status => $"{x} {y} {orientation}" + (isLost ? " LOST" : string.Empty);
    }
}
