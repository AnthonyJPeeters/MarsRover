using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CardanoMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = string.Empty;

            while (!userInput.ToLower().Equals("q"))
            {
                // First start the mission and check if the user input is 2D of ints
                MarsMissionStrings.SetupMission();
                do
                {
                    userInput = Console.ReadLine();
                } while (!InputHelper.IsValidStringForRegex(InputHelper.GetTwoNumberSeperatorRegex(), userInput));
                string[] gridDimensions = userInput.Split(' ');
                Mars mars = new Mars(int.Parse(gridDimensions[0]), int.Parse(gridDimensions[1]));
                uint amountOfrovers = 0;

                // Secondly check if the user has selected a valid amount of rovers
                MarsMissionStrings.SelectAmountOfRovers();
                do
                {
                    userInput = Console.ReadLine();
                } while (!uint.TryParse(userInput, out amountOfrovers));

                for (int i = 0; i < amountOfrovers; i++)
                {
                    MarsMissionStrings.RoverWithinBorders(i + 1);
                    bool isValidRover = false;
                    do
                    {
                        userInput = Console.ReadLine();
                        string[] userInputRovers = userInput.Split(' ');
                        // Check if the user inputs three values
                        if (userInputRovers.Length != 3)
                        {
                            continue;
                        }
                        int xAxisRover;
                        int yAxisRover;

                        //First to inputs have to be ints
                        if (!int.TryParse(userInputRovers[0], out xAxisRover) || !int.TryParse(userInputRovers[1], out yAxisRover))
                        {
                            continue;
                        }
                        else if (xAxisRover < 0 || yAxisRover < 0)
                        {
                            // User can't give negative values
                            continue;
                        }

                        //Last input has to be a cardinal direction
                        if (!InputHelper.IsCardinalDirectionInput(userInputRovers[2]))
                        {
                            continue;
                        }

                        Point roverLocation = new Point(xAxisRover, yAxisRover);

                        // Check if the user is within the grid
                        if (!mars.IsPointInGrid(roverLocation))
                        {
                            continue;
                        }

                        MarsRover rover = new MarsRover(InputHelper.GetCardinalDirection(userInputRovers[2]), roverLocation);
                        mars.PlaceRover(rover);
                        isValidRover = true;
                    } while (!isValidRover);
                }
                MarsMissionStrings.RoverSetupSucces();
                do
                {
                    MarsMissionStrings.SelectRover(amountOfrovers);
                    uint selectedRoverIndex;
                    bool containsRover = false;
                    do
                    {
                        userInput = Console.ReadLine();

                        // Has to be a valid int
                        if (!uint.TryParse(userInput, out selectedRoverIndex))
                        {
                            continue;
                        }

                        // Can't be higher then the amount of rovers also cant be below 1
                        if (selectedRoverIndex > mars.MarsRovers.Count || selectedRoverIndex < 1)
                        {
                            continue;
                        }

                        containsRover = true;
                    } while (!containsRover);

                    MarsMissionStrings.MoveRover();
                    do
                    {
                        MarsMissionStrings.AskLocation();

                        userInput = Console.ReadLine();
                        
                        if (userInput.ToLower().Equals("location"))
                        {
                            MarsMissionStrings.ShowLocation(mars.MarsRovers[Convert.ToInt32((selectedRoverIndex - 1))].MarsRover);
                        }

                        if (userInput.Length == 3)
                        {
                            bool isValidInput = true;
                            List<string> actions = new List<string>();
                            foreach (char input in userInput)
                            {
                                if (!InputHelper.IsValidMoveInput(input.ToString()))
                                {
                                    isValidInput = false;
                                }
                                actions.Add(input.ToString());
                            }

                            if (!isValidInput)
                            {
                                actions.Clear();
                                continue;
                            }

                            foreach (string action in actions)
                            {
                                mars.MoveRover(mars.MarsRovers[Convert.ToInt32((selectedRoverIndex - 1))].MarsRover,
                                    InputHelper.GetMove(action));
                            }


                        }
                    } while (!userInput.ToLower().Equals("b"));
                } while (!userInput.ToLower().Equals("q"));
            }

            // Features/improvements for V2:
            // Collision detection
            // Proper user input management
            // Translations
            // Imrpove general comments
        }
    }
}
