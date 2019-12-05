using CardanoMarsMission;
using System;

namespace CardanoMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {



            MarsRover rover1 = new MarsRover(CardinalDirection.South, new System.Drawing.Point(0, 0));
            Mars mars = new Mars(5, 5);
            mars.PlaceRover(rover1);
            mars.MoveRover(rover1, Move.Move);
            mars.MoveRover(rover1, Move.Move);
            bool t = InputHelper.IsValidMoveInput("n");
            bool tt = InputHelper.IsValidMoveInput("nm");

            MarsRoverContext context = new MarsRoverContext(new MarsRover(CardinalDirection.North, new System.Drawing.Point(1, 1)));
            Console.ReadKey();
        }
    }
}
