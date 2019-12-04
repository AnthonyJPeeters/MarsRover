using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public interface IState
    {
        void MoveRover(MarsRoverContext context);
    }
}
