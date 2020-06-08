using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree newTree;
            string path = "TreeTest.txt";

            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("( * ( + 1 ( / 6 2) ) 7 )");
            }

            using (StreamReader reader = new System.IO.StreamReader(path))
            {
                newTree = new Tree(reader);
            }

            Console.WriteLine(newTree.Calculate());
            newTree.Print();
        }
    }
}
