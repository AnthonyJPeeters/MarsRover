using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CardanoMarsMission
{
    public abstract class Planet
    {
        /// <summary>
        /// The size of the actual surface. False for an empty 'tile', true when the tile is occupied
        /// </summary>
        public bool[,] Size { get; private set; }

        /// <summary>
        /// Default all the tiles will false
        /// </summary>
        /// <param name="xSize">Will be representing the X-as</param>
        /// <param name="ySize">Will be representing the Y-as</param>
        public Planet(int xSize, int ySize)
        {
            Size = new bool[xSize, ySize];
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    Size[i, j] = false;
                }
            }
        }

        public void PlaceObject(Point point)
        {
            Size[point.X, point.Y] = true;
        }
    }
}
