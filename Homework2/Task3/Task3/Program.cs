using System;
using static Task3.Calculator;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a storage type: \"0\" = List, \"1\" = Array");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                stack = new StackAsList<float>();
            }
            else if (choice == 1)
            {
                stack = new StackAsArray<float>();
            }
            else
            {
                Console.WriteLine("You've entered a wrong value!");
            }

            while (true)
            {
                Console.WriteLine("Enter postfix expression to calculate. ");
                Console.WriteLine($"Result: {Calculator.Calculate(Console.ReadLine())}");
                Console.WriteLine($"Result: {Calculator.Calculate(Console.ReadLine())}");
            }
        } 
    }
}