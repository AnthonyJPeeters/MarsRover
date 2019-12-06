using CardanoMarsRover;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoMarsMission
{
    /// <summary>
    /// The Mars missions strings
    /// </summary>
    public static class MarsMissionStrings
    {
        public static void SetupMission()
        {
            Console.WriteLine("Welcome to the Cardano Mars mission.");
            Console.WriteLine("First of all we have to decide the Mars-grid size we will explore today.");
            Console.WriteLine("Please enter a grid size which is separated by a space like so: 5 5.");
            Console.WriteLine("First number will represent the X axis the second one will represent the Y axis");
            Console.WriteLine("(Keep in mind that the axis will start at 0 and not 1)");
        }

        public static void SelectAmountOfRovers()
        {
            Console.Write("Please select an amount of Mars rovers: ");
        }

        public static void RoverWithinBorders(int roverNumber)
        {
            Console.WriteLine($"Set the start location and facing direction of rover number {roverNumber} like so: 1 1 N");
        }

        public static void RoverSetupSucces()
        {
            Console.WriteLine("The rover(s) have been setup successfully");
        }

        public static void SelectRover(uint amountOfRovers)
        {
            if (amountOfRovers == 1)
            {
                Console.WriteLine("Please select rover number one");
            }
            else
            {
                Console.WriteLine($"Please select a rover up to {amountOfRovers}");
            }
        }

        public static void MoveRover()
        {
            Console.WriteLine("To move this rover user commands: L (left) R (right) M (move).");
            Console.WriteLine("There can only be three commands at a time.");
            Console.WriteLine("To go back and select another rover use B");
        }

        public static void AskLocation()
        {
            Console.WriteLine("Enter 'location' to see the current location of the rover");
        }

        public static void ShowLocation(MarsRover marsRover)
        {
            Console.WriteLine($"This mars rover is currently at X:{marsRover.Location.X} Y:{marsRover.Location.Y} facing: {marsRover.FacingDirection}");
        }
    }
}
