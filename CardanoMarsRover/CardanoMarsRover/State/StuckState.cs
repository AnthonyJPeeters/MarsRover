using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class StuckState : IState
    {
        public void MoveRover(MarsRoverContext context, Planet planet)
        {
            Console.WriteLine("The Mars rover is stuck. Please contact a mechanic.");
        }
    }
}
