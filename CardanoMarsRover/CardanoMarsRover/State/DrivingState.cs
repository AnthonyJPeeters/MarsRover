using CardanoMarsMission;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CardanoMarsRover
{
    public class DrivingState : IState
    {
        public void MoveRover(MarsRoverContext marsRoverContext, Planet planet)
        {
            // Note that I am mutating properties directly from the given arguments. It is better to avoid this because,
            // if for any reason the compiler decides to pas it by value instead of by ref, the method will not behave as expected.
            // Also I am aware of the ref keyword but still, the C# compiler should pass these objects by ref as default.
            int planetXAxis = planet.Size.GetLength(0);
            int planetYAxis = planet.Size.GetLength(1);

            Point currentPoint = marsRoverContext.MarsRover.Location;
            int currentX = marsRoverContext.MarsRover.Location.X;
            int currentY = marsRoverContext.MarsRover.Location.Y;
            int newX = 0, newY = 0;

            CardinalDirection cardinalDirectionRover = marsRoverContext.MarsRover.FacingDirection;

            // North move will cause +1 on the Y-axis
            // East move will cause a +1 on the X-axis
            // South move will cause a -1 on the Y-axis
            // West move will cause a -1 on the X-axis
            switch (cardinalDirectionRover)
            {
                case CardinalDirection.North:
                    newX = currentX;
                    newY = currentY + 1;
                    break;
                case CardinalDirection.East:
                    newX = currentX + 1;
                    newY = currentY;
                    break;
                case CardinalDirection.South:
                    newX = currentX;
                    newY = currentY - 1;
                    break;
                case CardinalDirection.West:
                    newX = currentX - 1;
                    newY = currentY;
                    break;
            }

            if (newY >= planetYAxis || newX >= planetXAxis || newY < 0 || newX < 0)
            {
                Console.WriteLine("The Mars rover is now out of the grid");
                marsRoverContext.SetState(new StuckState());
                return;
            }
            
            Point newMarsRoverLocation = new Point(newX, newY);

            // For collision later
            planet.RemoveObject(currentPoint);
            planet.PlaceObject(newMarsRoverLocation);
            marsRoverContext.MarsRover.SetNewLocation(newMarsRoverLocation);

            Console.WriteLine($"The Mars rover moved to X {newX} and Y {newY}");
            
        }
    }
}
