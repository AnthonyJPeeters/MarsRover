using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class Mars : Planet
    {
        public List<MarsRover> MarsRovers { get; private set; }

        public Mars(int xSize, int ySize)
            :base(xSize, ySize)
        {
            MarsRovers = new List<MarsRover>();
        }

        public void PlaceRover(MarsRover rover)
        {
            MarsRovers.Add(rover);
        }
    }
}
