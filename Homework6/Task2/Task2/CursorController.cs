using System;

namespace Task2
{
    /// <summary>
    /// Class that provides control over the player's position 
    /// and shows it on the screen.
    /// </summary>
    class CursorController
    {
        private Tilemap tilemap;

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
            => tilemap.Print();

        /// <summary>
        /// Moves left.
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveLeft();
            tilemap.Print();
        }

        /// <summary>
        /// Moves right.
        /// </summary>
        public void OnRight(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveRight();
            tilemap.Print();
        }

        /// <summary>
        /// Moves up.
        /// </summary>
        public void OnUp(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveUp();
            tilemap.Print();
        }

        /// <summary>
        /// Moves down.
        /// </summary>
        public void OnDown(object sender, EventArgs args)
        {
            Console.Clear();
            tilemap.MoveDown();
            tilemap.Print();
        }
    }
}
