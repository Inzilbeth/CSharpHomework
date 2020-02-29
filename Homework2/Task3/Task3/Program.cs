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
            IStack<float> stack;
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
                throw new Exception("You've entered a wrong value!");
            }
            var calculator = new Calculator(stack);
            while (true)
            {
                Console.WriteLine("Enter postfix expression to calculate. ");
                string expression = Console.ReadLine();
                Console.WriteLine($"Result: {calculator.Calculate(expression)}");
            }
        } 
    }
}