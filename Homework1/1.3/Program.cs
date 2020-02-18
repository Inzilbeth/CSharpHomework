using System;

namespace Homework1._3
{
    class Program
    {   
        private static void ArraySort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int tempVar = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempVar;
                    }
                } 
        }

        static int Main(string[] args)
        {
            Console.Write("Enter the size of the random array: ");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            if (arraySize <= 0)
            {
                Console.WriteLine("Entered value is inappropriate!");
                return 1;
            }
            int[] randomArray = new int[arraySize];
            Console.WriteLine("Your random array is: ");
            var rand = new Random();
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = rand.Next(0, arraySize);
                Console.Write($"{randomArray[i]} ");
            }
            ArraySort(randomArray);
            Console.WriteLine("\nYour sorted random array is: ");
            for (int i = 0; i < randomArray.Length; i++)
            {
                Console.Write("{0} ", randomArray[i]);
            }
            return 0;
        }
    }
}