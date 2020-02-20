using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        static int[,] GetArray(int n)
        {
            string[] line_array;
            int[,] array = new int[n, n];
            Console.WriteLine("Enter the elements of the array, separating them with spaces:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter row {i + 1} of the array: ");
                line_array = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = Convert.ToInt32(line_array[j]);
                }
            }
            return array;
        }

        static void spiralOutput(int[,] array)
        {
            // При truе выполнение закончится.
            bool detector = false;
            // Отвечает за изменение длины похода по направлению.
            int flag = 0;
            int moveSize = 0;
            char moveDirection = 'u';
            // Счетчик шагов.
            int steps = 0; 
            int i = array.Length/4 - 1;
            int j = array.Length/4 - 1;
            Console.WriteLine("Spiral output of your array is: ");
            Console.Write(array[i, j] + " ");
            while (steps < (array.Length - 1))
            {
                if (detector) { break; }
                if (flag % 2 == 0) { moveSize++; }
                if (moveDirection == 'u')
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        i--;
                        Console.Write(array[i, j] + " ");
                        steps++;
                        if (steps == array.Length - 1) { detector = true; break; }
                    }
                    moveDirection = 'l';
                    flag++;
                    continue;
                }
                if (moveDirection == 'l')
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        j--;
                        Console.Write(array[i, j] + " ");
                        steps++;
                        if (steps == array.Length - 1) { detector = true; break; }
                    }
                    moveDirection = 'd';
                    flag++;
                    continue;
                }
                if (moveDirection == 'd')
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        i++;
                        Console.Write(array[i, j] + " ");
                        steps++;
                        if (steps == array.Length - 1) { detector = true; break; }
                    }
                    moveDirection = 'r';
                    flag++;
                    continue;
                }
                if (moveDirection == 'r')
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        j++;
                        Console.Write(array[i, j] + " ");
                        steps++;
                        if (steps == array.Length - 1) { detector = true; break; }
                    }
                    moveDirection = 'u';
                    flag++;
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size<=0)
            {
                Console.WriteLine("Entered value is inappropriate!");
                return;
            }
            int[,] array = GetArray(size);
            Console.WriteLine(array.Length);
            Console.WriteLine("Your array is: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{array[i, j]} ");
                Console.Write(Environment.NewLine);
            }
            spiralOutput(array);
        }
    }
}