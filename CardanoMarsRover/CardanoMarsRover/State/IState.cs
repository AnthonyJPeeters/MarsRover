using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    public interface IState
    {
        void MoveRover(StateContext context, String name);
    }
}
