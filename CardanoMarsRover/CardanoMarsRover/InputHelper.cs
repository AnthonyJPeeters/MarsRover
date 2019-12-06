using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CardanoMarsMission
{
    public static class InputHelper
    {
        public static string GetTwoNumberSeperatorRegex()
        {
            return @"^\d+(?:\s+\d+){1}$";
        }

        public static bool IsValidStringForRegex(string regex, string input)
        {
            return Regex.Match(input, regex, RegexOptions.IgnoreCase).Success;
        }

        /// <summary>
        /// Gets all the moving possibilites for a Mars rover. I did it like this is 
        /// because the way it moves might change any given time. Lets say in the future we get this data from a database,
        /// if a wheel breaks, it might not be able to move forward but might still move left or right. Also if this is the case,
        /// this should become a property of the Mars rover itself. For now its just in the helper class.
        /// </summary>
        /// <returns>A list which returns all the positions the Mars rover can move in</returns>
        public static List<string> MovePossibilities()
        {
            List<string> moveValues = new List<string>();

            foreach (Move move in Enum.GetValues(typeof(Move)))
            {
                moveValues.Add(move.ToMoveString());
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

        /// <summary>
        /// Gets the cardinal directions in order
        /// </summary>
        /// <returns></returns>
        public static List<string> GetCardinalDirection()
        {
            List<string> moveValues = new List<string>();
            
            // Make sure the values are in the correct order
            moveValues.Add(CardinalDirection.North.ToCardinalDirectionString());
            moveValues.Add(CardinalDirection.East.ToCardinalDirectionString());
            moveValues.Add(CardinalDirection.South.ToCardinalDirectionString());
            moveValues.Add(CardinalDirection.West.ToCardinalDirectionString());

            return moveValues;
        }

        public static string ToCardinalDirectionString(this CardinalDirection move)
        {
            return ((char)move).ToString().ToLower();
        }

        public static bool IsCardinalDirectionInput(string cardinalDirection)
        {
            List<string> cardinalDirections = GetCardinalDirection();

            if (cardinalDirections.Contains(cardinalDirection.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// If I had more time I Would make this more generic
        /// </summary>
        /// <param name="cardinalDirection">The char of the belonging cardinaldirection</param>
        /// <returns></returns>
        public static CardinalDirection GetCardinalDirection(string cardinalDirection)
        {
            string cardinalDirectionFormatted = cardinalDirection.ToUpper();
            switch (cardinalDirectionFormatted)
            {
                case "N":
                    return CardanoMarsRover.CardinalDirection.North;
                case "E":
                    return CardanoMarsRover.CardinalDirection.East;
                case "S":
                    return CardanoMarsRover.CardinalDirection.South;
                case "W":
                    return CardanoMarsRover.CardinalDirection.West;
                default:
                    throw new Exception("Cardinal direction not found");
            }
        }

        public static Move GetMove(string move)
        {
            string convertedMove = move.ToUpper();
            switch (convertedMove)
            {
                case "L":
                    return Move.Left;
                case "R":
                    return Move.Right;
                case "M":
                    return Move.Move;
                default:
                    return Move.None;
            }
        }
    }
}
