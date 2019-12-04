using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public class ErrorState : IState
    {
        public void MoveRover(MarsRoverContext context, string name)
        {
            Console.WriteLine(name.ToLower());
        }
    }
}
