using System;

namespace Homework1._2
{
    class Program
    {
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
        static void Main(string[] args)
        {
            Console.WriteLine("#7 Fibonachi number is {0}", Fibonachi(7));
        }
    }
}
