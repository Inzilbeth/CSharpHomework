using System;


namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            if(size<=0)
            {
                Console.WriteLine("Entered value is inappropriate!");
                return;
            }
            int[,] arrayToSort = new int[size, size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    arrayToSort[i, j] = rand.Next(0, size*size);
            Console.WriteLine("Unsorted array: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{arrayToSort[i, j]} ");
                Console.Write(Environment.NewLine);
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (arrayToSort[0, j] > arrayToSort[0, j + 1])
                    {
                        for (int k = 0; k < size; k++)
                        {
                            int temporaryVariable = arrayToSort[k, j];
                            arrayToSort[k, j] = arrayToSort[k, j + 1];
                            arrayToSort[k, j + 1] = temporaryVariable;
                        }
                    }
                }
            }
            Console.WriteLine("\nSorted array: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{arrayToSort[i, j]} ");
                Console.Write(Environment.NewLine);
            }
        }
    }
}
