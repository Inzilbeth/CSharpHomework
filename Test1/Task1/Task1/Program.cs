using System;

namespace Task1
{
    /// <summary>
    /// Demonstration of priorityQueue class.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var pQueue = new PriorityQueue<string>();
            pQueue.Enqueue("priority 1", 1);
            pQueue.Enqueue("priority 10", 10);
            pQueue.Enqueue("priority 5", 5);


            pQueue.Print();

            Console.WriteLine();
            
            Console.WriteLine($"deleted {pQueue.Dequeue()}");
            
            Console.WriteLine();

            pQueue.Print();

            Console.WriteLine();

            Console.WriteLine($"deleted {pQueue.Dequeue()}");


            Console.WriteLine();

            pQueue.Print();
        }
    }
}
