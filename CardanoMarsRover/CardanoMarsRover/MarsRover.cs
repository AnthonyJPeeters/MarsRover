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
        public Guid VehicleGuid { get;  }
        public MarsRover(CardinalDirection facingDirection, Point startLocation)
        {
            VehicleGuid = Guid.NewGuid();
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

        /// <summary>
        /// Sets the new location of the mars rover
        /// </summary>
        /// <param name="point">the new location of the mars rover</param>
        public void SetNewLocation(Point point)
        {
            Location = point;
        }

        /// <summary>
        /// Compares mars rovers of the context. 
        /// </summary>
        /// <param name="obj">The Mars rover to compare it to</param>
        /// <returns>True when the VehicleGuid's match</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(MarsRover))
            {
                return false;
            }
            MarsRover marsRover = (MarsRover)obj;

            if (marsRover.VehicleGuid.Equals(this.VehicleGuid))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.VehicleGuid.GetHashCode();
        }
    }

    public enum CardinalDirection 
    {
        North = 'N',
        East = 'E',
        South = 'S',
        West = 'W'
    }

    public enum Move
    {
        Left = 'L',
        Right = 'R',
        Move = 'M',
        None = 'N'
    }
}
