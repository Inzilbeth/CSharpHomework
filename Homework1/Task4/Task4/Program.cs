/*using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task4
{
    class Program
    {
   

        static int[,] GetArray(int n)
        {
            string line;
            string[] line_array;
            int[,] array = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                line = Console.ReadLine();
                line_array = line.Split(" ");
                for(int j = 0; j < n; j++)
                {
                    array[i, j] = Convert.ToInt32(line_array[j]);
                }
            }
            return array;
        }
        static void SpiralOutput(int[,] array,int size)
        {
            int phase = 0;
            int i = size / 2, j = size / 2;
            int stepsDone = 0;
            int amountOfSteps = 1;
            char moveDirection = 'u';
            for (int k=0;k<size*size;k++)
            {
                switch (moveDirection) // u = up, l = left, d = down, r = right
                {
                    case 'u':
                        stepsDone++;
                        Console.Write("{0} ", array[i, j]);
                        i--;
                        if (stepsDone == amountOfSteps)
                        {
                            moveDirection = 'l';
                            stepsDone = 0;
                            phase++;
                            if (phase % 2 == 0)
                                amountOfSteps++;
                        }
                        break;
                    case 'l':
                        stepsDone++;
                        phase++;
                        Console.Write("{0} ", array[i, j]);
                        j--;
                        if (stepsDone == amountOfSteps)
                        {
                            moveDirection = 'd';
                            stepsDone = 0;
                            phase++;
                            if (phase % 2 == 0)
                                amountOfSteps++;
                        }
                            break;
                    case 'd':
                        stepsDone++;
                        phase++;
                        Console.Write("{0} ", array[i, j]);
                        i++;
                        if (stepsDone == amountOfSteps)
                        {
                            moveDirection = 'r';
                            stepsDone = 0;
                            phase++;
                            if (phase % 2 == 0)
                                amountOfSteps++;
                        }
                            break;
                    case 'r':
                        stepsDone++;
                        phase++;
                        Console.Write("{0} ", array[i, j]);
                        j++;
                        if (stepsDone == amountOfSteps)
                        {
                            moveDirection = 'u';
                            stepsDone = 0;
                            phase++;
                            if (phase % 2 == 0)
                                amountOfSteps++;
                        }
                            break;
                }
            }
        }
        static void Main(string[] args)
        {
            int size;
            size = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[size, size];
            //array =  GetArray(size);
            int k = 10;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = k;
                    k++;
                }
            for (int i = 0; i < size; i++)
            {
                Console.Write(Environment.NewLine);
                for (int j = 0; j < size; j++)
                    Console.Write("{0} ", array[i, j]);
            }
            Console.Write(Environment.NewLine);
            SpiralOutput(array, size);
        }
    }
} */
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
            for (int i = 0; i < n; i++)
            {
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
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] array = GetArray(size);
            spiralOutput(array, size);
        }
    }
}