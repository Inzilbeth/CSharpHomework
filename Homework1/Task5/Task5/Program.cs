using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfLine = 15, sizeOfColumn = 15;
            int[,] arrayToSort = new int[sizeOfLine, sizeOfColumn];
            Random rand = new Random();

            for (int i = 0; i < sizeOfColumn; i++)
                for (int j = 0; j < sizeOfLine; j++)
                    arrayToSort[i, j] = rand.Next(0, 1000);
            Console.Write("Unsorted array:", Environment.NewLine);
            for (int i = 0; i < sizeOfColumn; i++)
            {
                Console.Write(Environment.NewLine);
                for (int j = 0; j < sizeOfLine; j++)
                    Console.Write("{0} ", arrayToSort[i, j]);
            }
            for (int i = 0; i < sizeOfLine; i++)
            {
                for (int j = 0; j < sizeOfLine - 1; j++)
                {
                    if (arrayToSort[0, j] < arrayToSort[0, j + 1])
                    {
                        for (int k = 0; k < sizeOfColumn; k++)
                        {
                            int temporaryVariable = arrayToSort[k, j];
                            arrayToSort[k, j] = arrayToSort[k, j + 1];
                            arrayToSort[k, j + 1] = temporaryVariable;
                        }
                    }
                }
            }
            Console.Write("\nSorted array:", Environment.NewLine);
            for (int i = 0; i < sizeOfColumn; i++)
            {
                Console.Write(Environment.NewLine);
                for (int j = 0; j < sizeOfLine; j++)
                    Console.Write("{0} ", arrayToSort[i, j]);
            }
        }
    }
}
