using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class DrivingState : IState
    {
        public void MoveRover(MarsRoverContext context)
        {
            Console.WriteLine("The Mars rover moved into an obstacle...");
            // TODO: Check if the mars rover is out of boundries after the next move, if so, change to error state

            context.SetState(new StuckState());
        }
    }
}
