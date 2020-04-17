using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class PriorityQueue<T>
    {
        private LinkedList<T> priorityQueue;

        public PriorityQueue()
        {
            priorityQueue = new LinkedList<T>(); 
        }

        public void Enqueue(T data, int priority)
        {
            priorityQueue.AddByNumber(1, data, priority);
        }

        public T Dequeue()
        {
            if(priorityQueue.IsEmpty)
            {
                throw new ArgumentException();
            }

            var array = priorityQueue.ReturnAllNodes();
            int MaxPriority = array[0].Item2;
            int elementToDelete = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Item2 >= MaxPriority)
                {
                    MaxPriority = array[i].Item2;
                    elementToDelete = i;
                }
            }

            priorityQueue.RemoveByNumber(elementToDelete + 1);
            return array[elementToDelete].Item1;
        }

        public void Print()
        {
            foreach(var item in priorityQueue)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
