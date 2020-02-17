using System;

namespace Homework1._1
{
    class Program
    {
        private static int Factorial(int n)
            => n <= 1 ? 1 : n * Factorial(n - 1);
        static void Main(string[] args)
        {
            Console.Write("Enter value: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Factorial of {number} is {Factorial(number)}");
        }
    }
}
