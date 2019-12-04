using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsMission.State
{
    public class CollidingState : IState
    {
        public void MoveRover(MarsRoverContext context)
        {
            Console.WriteLine("This movement is not possible due collision");
            // Don't move the Mars rover but instead move the state back
            context.SetState(new DrivingState());
        }
    }
}
