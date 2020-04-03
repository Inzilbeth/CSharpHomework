using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task2
{
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

        private bool IsOnMap(int x, int y)
        {
            if (x < height - 1 && y < width - 1)
            {
                return true;
            }
            return false;
        }

        public void MoveRight()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 + 1))
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1, playerPosition.Item2 + 1] = '@';
                playerPosition.Item2++;
            }
        }

        public void MoveLeft()
        {
            if (IsOnMap(playerPosition.Item1, playerPosition.Item2 - 1))
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1, playerPosition.Item2 - 1] = '@';
                playerPosition.Item2--;
            }
        }

        public void MoveDown()
        {
            if (IsOnMap(playerPosition.Item1 + 1, playerPosition.Item2))
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1 + 1, playerPosition.Item2] = '@';
                playerPosition.Item1++;
            }
        }

        public void MoveUp()
        {
            if (IsOnMap(playerPosition.Item1 - 1, playerPosition.Item2 + 1))
            {
                map[playerPosition.Item1, playerPosition.Item2] = ' ';
                map[playerPosition.Item1 - 1, playerPosition.Item2] = '@';
                playerPosition.Item1--;
            }
        }

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
