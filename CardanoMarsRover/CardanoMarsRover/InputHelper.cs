using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsMission
{
    public static class InputHelper
    {
        /// <summary>
        /// Gets all the moving possibilites for a Mars rover. I did it like this is 
        /// because the way it moves might change any given time. Lets say in the future we get this data from a database,
        /// if a wheel breaks, it might not be able to move forward but might still move left or right. Also if this is the case,
        /// this should become a property of the Mars rover itself. For now its just in the helper class.
        /// </summary>
        /// <returns>A list which returns all the positions the Mars rover can move in</returns>
        private static List<string> MovePossibilities()
        {
            List<string> moveValues = new List<string>();

            foreach (Move item in Enum.GetValues(typeof(Move)))
            {
                moveValues.Add(item.ToMoveString());
            }

            return moveValues;
        }

        public static string ToMoveString(this Move move)
        {
            return ((char)move).ToString().ToLower();
        }

        public static bool IsValidMoveInput(string move)
        {
            List<string> movePossibilities = MovePossibilities();
            
            if (movePossibilities.Contains(move.ToLower()))
            {
                return true;
            }

            return false;
        }
    }
}
