using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class Mars : Planet
    {
        public List<MarsRoverContext> MarsRovers { get; private set; }

        public Mars(int xSize, int ySize)
            :base(xSize, ySize)
        {
            MarsRovers = new List<MarsRoverContext>();
        }

        /// <summary>
        /// Places the rover on the surface of Mars
        /// </summary>
        /// <param name="rover">The rover to put on Mars</param>
        public void PlaceRover(MarsRover rover)
        {
            MarsRovers.Add(new MarsRoverContext(rover));
            PlaceObject(rover.Location);
        }

        public void MoveRover(MarsRover marsRover, Move marsRoverMove)
        {
            MarsRoverContext marsRoverResult = MarsRovers.Find(rover => rover.MarsRover.Equals(marsRover));

            if (marsRoverResult == null)
            {
                throw new Exception("Mars rover not found.");
            }

            marsRoverResult.MoveRover(marsRoverMove, this);
        }
    }
}
