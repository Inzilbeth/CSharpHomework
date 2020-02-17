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

        static void spiralOutput(int[,] array, int size)
        {
            bool detector = false; //truе -> выполнение закончится
            int flag = 0; //Отвечает за изменение длины похода по направлению (1>1>2>2>3>3...)
            int moveSize = 0;
            char moveDirection = 'u';
            int steps = 0; //Счетчик шагов
            int i = size / 2;
            int j = size / 2;
            Console.WriteLine("Spiral output of your array is: ");
            Console.Write(array[i, j] + " ");
            while (steps < size * size)
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
                        if (steps == size * size - 1) { detector = true; break; }
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
                        if (steps == size * size - 1) { detector = true; break; }
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
                        if (steps == size * size - 1) { detector = true; break; }
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
                        if (steps == size * size - 1) { detector = true; break; }
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
            int[,] array = GetArray(size);
            Console.WriteLine("Your array is: ");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write($"{array[i, j]} ");
                Console.Write(Environment.NewLine);
            }
            spiralOutput(array, size);
        }
    }
}