using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsMission
{
    public static class InputHelper
    {
        /// <summary>
        /// Gets all the moving possibilites for a Mars rover. The reason I did it like this is 
        /// because the way it moves might change any given time. Lets say in the future we get this data from a database,
        /// if a wheel breaks, it might not be able to move forward but might still move left or right. Also if this is the case,
        /// this should become a property of the Mars rover itself. For now its just in the helper class.
        /// </summary>
        /// <returns>A list which returns all the positions the Mars rover can move in</returns>
        private static List<string> MovePosibillities()
        {
            Array underlayingTypes = Enum.GetValues(typeof(Move));
            List<string> moveValues = new List<string>();
            for (int i = 0; i < underlayingTypes.Length; i++)
            {
                moveValues.Add(Convert.ToString(underlayingTypes.GetValue(i)).ToLower());
            }
            return moveValues;
        }

        public static Boolean IsValidMove(this string move)
        {



            return true;
        }
    }
}
