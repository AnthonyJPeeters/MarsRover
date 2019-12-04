using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CardanoMarsRover
{
    public class MarsRover : IRemoteVehicle
    {
        public int AmountOfWheels { get; }

        /// <summary>
        /// The direction the Mars rover is currently facing
        /// </summary>
        public CardinalDirection FacingDirection { get; private set; }

        /// <summary>
        /// Current location of the Mars rover
        /// </summary>
        public Point Location { get; private set; }

        public MarsRover(CardinalDirection facingDirection, Point startLocation)
        {
            AmountOfWheels = 6;
            FacingDirection = facingDirection;
            Location = startLocation;
        }

        /// <summary>
        /// Changes the direction in which the Mars rover is facing
        /// </summary>
        /// <param name="facingDirection">The new direction the Mars rover should face</param>
        /// <returns></returns>
        public CardinalDirection ChangeFacingDirection(CardinalDirection facingDirection)
        {
            FacingDirection = facingDirection;
            return facingDirection;
        }

    }

    public enum CardinalDirection
    {
        North = 'N',
        East = 'E',
        South = 'S',
        West = 'W'
    }
}
