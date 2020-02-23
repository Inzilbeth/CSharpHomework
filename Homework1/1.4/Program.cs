using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
        private static int[,] GetArray(int n)
        {
            string[] lineArray;
            int[,] array = new int[n, n];
            Console.WriteLine("Enter the elements of the array, separating them with spaces:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter row {i + 1} of the array: ");
                lineArray = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = Convert.ToInt32(lineArray[j]);
                }
            }
            return array;
        }

        public enum MoveDirection { Up = 1, Left = 2, Down = 3, Right = 4 };

        private static void SpiralOutput(int[,] array)
        {
            bool isFinished = false;
            // Отвечает за изменение длины похода по направлению.
            int flag = 0;
            int moveSize = 0;
            MoveDirection direction = MoveDirection.Up;
            // Счетчик шагов.
            int steps = 0; 
            int i = (Convert.ToInt32(Math.Sqrt(array.Length))/2);
            int j = (Convert.ToInt32(Math.Sqrt(array.Length))/2);
            Console.WriteLine("Spiral output of your array is: ");
            Console.Write($"{array[i, j]} ");
            while (steps < (array.Length - 1))
            {
                if (isFinished) 
                { 
                    break; 
                }
                if (flag % 2 == 0) 
                {
                    moveSize++; 
                }
                if (direction == MoveDirection.Up)
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        i--;
                        Console.Write($"{array[i, j]} ");
                        steps++;
                        if (steps == array.Length - 1) 
                        { 
                            isFinished = true; 
                            break;
                        }
                    }
                    direction++;
                    flag++;
                    continue;
                }
                if (direction == MoveDirection.Left)
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        j--;
                        Console.Write($"{array[i, j]} ");
                        steps++;
                        if (steps == array.Length - 1) 
                        { 
                            isFinished = true; 
                            break; 
                        }
                    }
                    direction++;
                    flag++;
                    continue;
                }
                if (direction == MoveDirection.Down)
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        i++;
                        Console.Write($"{array[i, j]} ");
                        steps++;
                        if (steps == array.Length - 1) 
                        { 
                            isFinished = true; 
                            break; 
                        }
                    }
                    direction++;
                    flag++;
                    continue;
                }
                if (direction == MoveDirection.Right)
                {
                    for (int t = 0; t < moveSize; t++)
                    {
                        j++;
                        Console.Write($"{array[i, j]} ");
                        steps++;
                        if (steps == array.Length - 1) 
                        {
                            isFinished = true; 
                            break; 
                        }
                    }
                    direction = MoveDirection.Up;
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
            SpiralOutput(array);
        }
    }
}