using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public bool IsPointInGrid(Point point)
        {
            int planetXAxis = Size.GetLength(0);
            int planetYAxis = Size.GetLength(1);

            if (point.Y >= planetYAxis || point.X >= planetXAxis || point.Y < 0 || point.X < 0)
            {
                return false;
            }
            return true;
        }
    }
}
