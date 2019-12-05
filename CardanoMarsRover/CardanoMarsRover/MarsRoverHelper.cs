using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsMission
{
    public static class MarsRoverHelper
    {
        /// <summary>
        /// Gets the next cardinal direction of the mars rover
        /// </summary>
        /// <param name="marsRover">The mars rover with a cardinal direction</param>
        /// <param name="nextMove">The next move the mars rover will take</param>
        /// <returns></returns>
        public static CardinalDirection GetCardinalDirection(MarsRover marsRover, Move nextMove)
        {
            List<string> cardinalDirections = InputHelper.GetCardinalDirection();
            int indexOfCardinalDirection = cardinalDirections
                .FindIndex(cd => cd.ToLower().Equals(marsRover.FacingDirection.ToCardinalDirectionString()));
            int nextMoveIndex = 0;

            switch (nextMove)
            {
                case Move.Left:
                    // Move 'left' in the list
                    nextMoveIndex = -1;
                    break;
                case Move.Right:
                    // Move 'right' in the list
                    nextMoveIndex = 1;
                    break;
            }
             
            int nextMoveCount = indexOfCardinalDirection + nextMoveIndex;

            if (nextMoveCount < 0)
            {
                // -1 because index != count. Count returns one higher then an index
                return InputHelper.GetCardinalDirection(cardinalDirections[cardinalDirections.Count - 1]);
            }
            else if (nextMoveCount == cardinalDirections.Count)
            {
                // Wrap around the list
                return InputHelper.GetCardinalDirection(cardinalDirections[0]);
            }
            else
            {
                return InputHelper.GetCardinalDirection(cardinalDirections[nextMoveCount]);
            }
        }

    }
}
