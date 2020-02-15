using System;

namespace Homework1._3
{
    class Program
    {   
        static void Main(string[] args)
        {
            int array_size = 100;
            int[] random_array = new int[array_size];
            Random rand = new Random();
            for (int i = 0; i < random_array.Length; i++)
                random_array[i] = rand.Next(0,1000);
            Array.Sort(random_array);
            Console.WriteLine("Your sorted random array is: ");
            for (int i=0;i< random_array.Length;i++)
                Console.Write("{0} ",random_array[i]);
        }
    }
}
