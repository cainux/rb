using System;
using System.Collections.Generic;

namespace RB.Core
{
    public class Planet
    {
        private int width;
        private int height;
        private IList<Robot> robots;
        private HashSet<Tuple<int, int>> scents;

        public Planet(int width, int height)
        {
            this.width = width;
            this.height = height;

            robots = new List<Robot>();
            scents = new HashSet<Tuple<int, int>>();
        }

        public void AddRobot(int x, int y, char orientation, string instructions)
        {
            throw new NotImplementedException();
        }

        public void RunRobots()
        {
            throw new NotImplementedException();
        }
    }
}
