using System;

/// <summary>
/// Gloobal namespace.
/// </summary>
namespace hw4Task1
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

            var newtree = new Tree(path);

            Console.WriteLine(newtree.Calculate());
            newtree.Print();
        }
    }
}
