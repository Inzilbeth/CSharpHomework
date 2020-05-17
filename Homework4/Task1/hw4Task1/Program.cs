using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "TreeTest.txt";
            using (System.IO.StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine("( * ( + 1 ( / 6 2) ) 7 )");
            }
            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            var newtree = new Tree(reader);

            Console.WriteLine(newtree.Calculate());
            newtree.Print();
        }
    }
}
