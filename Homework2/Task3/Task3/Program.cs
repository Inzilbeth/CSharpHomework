using System;
using static Task3.StackCalculator;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter postfix expression to calculate. ");
                Console.WriteLine("First expression will be calculated using list, another one - using array");
                Console.WriteLine($"Result: {StackCalculator.Calculate(Console.ReadLine(), StorageType.List)}");
                Console.WriteLine($"Result: {StackCalculator.Calculate(Console.ReadLine(), StorageType.Array)}");
            }
        } 
    }
}