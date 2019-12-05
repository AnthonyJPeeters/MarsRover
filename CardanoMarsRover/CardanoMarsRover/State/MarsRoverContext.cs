using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CardanoMarsRover
{
    public class MarsRoverContext
    {
        private IState state;
        public MarsRover MarsRover { get; }
        public MarsRoverContext(MarsRover marsRover)
        {
            state = new DrivingState();
            MarsRover = marsRover;
        }
        public MarsRoverContext(CardinalDirection marsRoverDirection, Point startLocation)
        {
            state = new DrivingState();
            MarsRover = new MarsRover(marsRoverDirection, startLocation);
        }

        public void SetState(IState newState)
        {
            state = newState;
        }

        public void MoveRover(Move move, Planet planet)
        {
            if (move != Move.Move)
            {
                // Get the next direction the Rover is facing
                MarsRover.ChangeFacingDirection(MarsRoverHelper.GetCardinalDirection(MarsRover, move));
            }
            else
            {
                // Move the actual mars rover on the planet
                state.MoveRover(this, planet);
            }
        }
    }
}
