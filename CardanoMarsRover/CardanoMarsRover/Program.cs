using System;

namespace CardanoMarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Mars p = new Mars(5, 5);
            Array underlayingTypes = Enum.GetValues(typeof(Move));

            MarsRoverContext context = new MarsRoverContext(new MarsRover(CardinalDirection.North, new System.Drawing.Point(1, 1)));
            context.MoveRover();
            context.MoveRover();
            Console.ReadKey();
        }
    }
}
