using System;

namespace Homework1._1
{
    class Program
    {
        private static int Factorial(int n)
            => n <= 1 ? 1 : n * Factorial(n - 1);
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial of 7 is: {0}",Factorial(7));
        }
    }
}
