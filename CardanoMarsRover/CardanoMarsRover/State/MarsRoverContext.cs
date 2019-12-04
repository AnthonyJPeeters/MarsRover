using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CardanoMarsRover
{
    public class MarsRoverContext
    {
        private IState state;
        private MarsRover MarsRover;
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

        public void MoveRover()
        {
            state.MoveRover(this);
        }
    }
}
