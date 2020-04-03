using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class CursorController
    {
        Tilemap tilemap;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="path">Path to the map file.</param>
        public CursorController(string path)
        {
            tilemap = new Tilemap(path);
        }

        /// <summary>
        /// Prints the map.
        /// </summary>
        public void Print()
        {
            tilemap.Print();
        }

        /// <summary>
        /// Moves left.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnLeft(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveLeft();
            tilemap.Print();
        }

        /// <summary>
        /// Moves right.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnRight(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveRight();
            tilemap.Print();
        }

        /// <summary>
        /// Moves up.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnUp(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveUp();
            tilemap.Print();
        }

        /// <summary>
        /// Moves down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDown(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveDown();
            tilemap.Print();
        }
    }
}
