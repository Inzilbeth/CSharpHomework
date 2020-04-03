using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmap = new Tilemap(@"C:\Users\Талгат\Desktop\map.txt");
            tmap.Print();
            tmap.MoveUp();
            tmap.Print();
            tmap.MoveUp();
            tmap.Print();
            tmap.MoveUp();
            tmap.Print();
            tmap.MoveRight();
            tmap.Print();
        }
    }
}
