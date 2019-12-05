using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsRover
{
    /// <summary>
    /// State actions for the Mars Rover
    /// </summary>
    public interface IState
    {
        void MoveRover(MarsRoverContext context, Planet planet);
    }
}
