using System;

namespace Task1
{
    /// <summary>
    /// Implementation of priority queue.
    /// </summary>
    /// <typeparam name="T">Type of stored data</typeparam>
    public class PriorityQueue<T>
    {
        private LinkedList<T> priorityQueue;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PriorityQueue()
        {
            priorityQueue = new LinkedList<T>(); 
        }

        /// <summary>
        /// Adds an element to the queue.
        /// </summary>
        /// <param name="data">Element's data.</param>
        /// <param name="priority">Element's priority</param>
        public void Enqueue(T data, int priority)
        {
            priorityQueue.AddByNumber(1, data, priority);
        }

        /// <summary>
        /// Deletes element with the highest priority.
        /// </summary>
        /// <returns>Data of deleted element.</returns>
        public T Dequeue()
        {
            if(priorityQueue.IsEmpty)
            {
                throw new ArgumentException();
            }

            // Не очень круто, но что поделать...
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

        /// <summary>
        /// Prints the queue.
        /// </summary>
        public void Print()
        {
            foreach(var item in priorityQueue)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /// <summary>
        /// Checks if the queue is empty.
        /// </summary>
        /// <returns>Whether the queue is empty.</returns>
        public bool IsEmpty()
            => priorityQueue.IsEmpty;
    }
}
