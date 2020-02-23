using System;


namespace Task5
{
    class Program
    {
        static void SwapColumns(int[,] array, int k, int j)
        {
            int temporaryVariable = array[k, j];
            array[k, j] = array[k, j + 1];
            array[k, j + 1] = temporaryVariable;
        }

        static void Sort2DArrsColumns(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[0, j] > array[0, j + 1])
                    {
                        for (int k = 0; k < array.GetLength(1); k++)
                        {
                            SwapColumns(array, k, j);
                        }
                    }
                }
            }
        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        static void Initialize2DArray(int[,] array)
        {
            var rand = new Random();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rand.Next(0, array.Length);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size <= 0)
            {
                Console.WriteLine("Entered value is inappropriate!");
                return;
            }
            var arrayToSort = new int[size, size];
            Initialize2DArray(arrayToSort);
            Console.WriteLine("Unsorted array: ");
            Print2DArray(arrayToSort);
            Sort2DArrsColumns(arrayToSort);
            Console.WriteLine("\nSorted array: ");
            Print2DArray(arrayToSort);
        }
    }
}

