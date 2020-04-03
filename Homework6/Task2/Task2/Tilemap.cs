using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Tilemap class implementation.
    /// </summary>
    public class Tilemap
    {
        private int width;
        public int Width
            => width;

        private int height;
        public int Height
            => height;

        private char[,] map;
        public char[,] Map
            => map;

        (int, int) playerPosition;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="path">Path to a file with a map.</param>
        public Tilemap(string path)
        {
            width = 0;
            height = 0;
            string mapString;

            using(var sr = new StreamReader(path))
            {
                if ((mapString = sr.ReadLine()) != null)
                {
                    height++;
                    foreach (char c in mapString)
                    {
                        width++;
                    }
                }

                while(sr.ReadLine() != null)
                {
                    height++;
                }

                map = new char[height, width];

                sr.BaseStream.Position = 0;

                for (int i = 0; i < height; i++)
                {
                    mapString = sr.ReadLine();
                    for (int j = 0; j < width; j++)
                    {
                        if (mapString[j] == '@')
                        {
                            playerPosition = (i, j);
                        }
                        map[i, j] = mapString[j];
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the coordinates are within a map.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordiante</param>
        /// <returns>Whether the coordinates are within a map.</returns>
        public bool IsOnMap(int x, int y)
        {
            if (x < height - 1 && y < width - 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Moves player right if possible.
        /// </summary>
        public void MoveRight()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 + 1)
                && map[playerPosition.Item1, playerPosition.Item2 + 1] != '#')
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1, playerPosition.Item2 + 1] = '@';
                playerPosition.Item2++;
            }
        }

        /// <summary>
        /// Moves player left if possible.
        /// </summary>
        public void MoveLeft()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 - 1)
                && map[playerPosition.Item1, playerPosition.Item2 - 1] != '#')
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1, playerPosition.Item2 - 1] = '@';
                playerPosition.Item2--;
            }
        }

        /// <summary>
        /// Moves player down if possible.
        /// </summary>
        public void MoveDown()
        {
            if (IsOnMap(playerPosition.Item1 + 1, playerPosition.Item2)
                && map[playerPosition.Item1 + 1, playerPosition.Item2] != '#')
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1 + 1, playerPosition.Item2] = '@';
                playerPosition.Item1++;
            }
        }

        /// <summary>
        /// Moves player up if possible.
        /// </summary>
        public void MoveUp()
        {
            if (IsOnMap(playerPosition.Item1 - 1, playerPosition.Item2)
                && map[playerPosition.Item1 - 1, playerPosition.Item2] != '#')
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1 - 1, playerPosition.Item2] = '@';
                playerPosition.Item1--;
            }
        }

        /// <summary>
        /// Prints the map.
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < width; j++)
                {
                    Console.Write(Map[i, j]);
                }
            }
        }
    }
}
