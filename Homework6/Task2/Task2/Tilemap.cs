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
                        map[i, j] = mapString[j];
                    }
                }
            }
        }
    }
}
