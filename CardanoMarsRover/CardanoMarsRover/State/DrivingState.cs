using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class DrivingState : IState
    {
        public void MoveRover(MarsRoverContext context, string name)
        {
            Console.WriteLine("The Mars rover moved into a ditch...");
            context.SetState(new ErrorState());
        }
    }
}
