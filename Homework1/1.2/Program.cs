using System;

namespace Homework1._2
{
    class Program
    {
<<<<<<< Updated upstream
        private static int Fibonachi(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
		
=======
        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }

>>>>>>> Stashed changes
        static void Main(string[] args)
        {
            Console.Write("Enter value: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"#{number} Fibonachi number is {Fibonachi(number)}") ;
        }
    }
}
