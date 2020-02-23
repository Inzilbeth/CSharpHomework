using System;


namespace Task5
{
    class Program
    {
        static void Sort2DArrsColumns(int[,] array)
        {
            for (int i = 0; i < (Math.Sqrt(array.Length)); i++)
            {
                for (int j = 0; j < (Math.Sqrt(array.Length) - 1); j++)
                {
                    if (array[0, j] > array[0, j + 1])
                    {
                        for (int k = 0; k < (Math.Sqrt(array.Length)); k++)
                        {
                            int temporaryVariable = array[k, j];
                            array[k, j] = array[k, j + 1];
                            array[k, j + 1] = temporaryVariable;
                        }
                    }
                }
            }
        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < (Math.Sqrt(array.Length)); i++)
            {
                for (int j = 0; j < (Math.Sqrt(array.Length)); j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        static void Initialize2DArray(int[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < (Math.Sqrt(array.Length)) ; i++)
            {
                for (int j = 0; j < (Math.Sqrt(array.Length)); j++)
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
