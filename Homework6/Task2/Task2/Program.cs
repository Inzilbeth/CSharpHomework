using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmap = new Tilemap(@"C:\Users\Талгат\Desktop\map.txt");
            for (int i = 0; i < tmap.Height; i++)
            { Console.WriteLine();
                for (int j = 0; j < tmap.Width; j++)
                {
                    Console.Write(tmap.Map[i, j]);
                }
            }
        }
    }
}
