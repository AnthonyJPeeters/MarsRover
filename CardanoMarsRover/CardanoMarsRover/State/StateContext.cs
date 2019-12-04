using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class StateContext
    {
        private IState state;
        public StateContext()
        {
            state = new DrivingState();
        }

        public void SetState(IState newState)
        {
            state = newState;
        }

        public void MoveRover(String name)
        {
            state.MoveRover(this, name);
        }
    }
}
