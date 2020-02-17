using System;

namespace Homework1._3
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.Write("Enter the size of the random array: ");
            int array_size = Convert.ToInt32(Console.ReadLine());
            int[] random_array = new int[array_size];
            Console.WriteLine("Your random array is: ");
            Random rand = new Random();
            for (int i = 0; i < random_array.Length; i++)
            {
                random_array[i] = rand.Next(0, array_size);
                Console.Write($"{random_array[i]} ");
            }
            Array.Sort(random_array);
            Console.WriteLine("\nYour sorted random array is: ");
            for (int i = 0; i < random_array.Length; i++)
                Console.Write("{0} ", random_array[i]);
        }
    }
}
