using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class HashTable
    {
        /// <summary>
        /// Linked List.
        /// </summary>
        /// <typeparam Type = "T">Linked list's element type.</typeparam>
        public class LinkedList<T> : IEnumerable<T>
        {
            /// <summary>
            /// Linked list's element.
            /// </summary>
            /// <typeparam name="T">Type of data storaged within the element</typeparam>
            private class Node<T>
            {
                public Node(T data)
                {
                    Data = data;
                }
                public T Data { get; set; }
                public Node<T> Next { get; set; }
            }

            /// <summary>
            /// Head( = first) element of the linked list.
            /// </summary>
            private Node<T> head;

            /// <summary>
            /// Tail( = last) element of the linked list.
            /// </summary>
            private Node<T> tail;

            /// <summary>
            /// The amount of currently stored elements within a linked list.
            /// </summary>
            private int count;

            /// <summary>
            /// Adds an element with the entered position and value to the linked list.
            /// </summary>
            /// <param name="number">Position where the element will be placed in the linked list.</param>
            /// <param name="data">Information that will be stored within the element</param>
            public void AddByNumber(int number, T data)
            {
                if (number > count + 1 || number < 0)
                {
                    Console.WriteLine("Entered wrong value!");
                    return;
                }

                var node = new Node<T>(data);
                var current = head;
                Node<T> previous = null;

                for (int i = 1; i < number; i++)
                {
                    previous = current;
                    current = current.Next;
                }

                if (number == 1)
                {
                    head = node;
                }
                if (number == count + 1)
                {
                    tail = node;
                }
                if (previous != null)
                {
                    previous.Next = node;
                }
                node.Next = current;

                count++;
            }

            /// <summary>
            /// Adds an element with the entered value from the linked list.
            /// </summary>
            /// <param name="data">Data, element with which will be deleted from the linked list.</param>
            /// <returns>Indicates whether the removal was successful.</returns>
            public bool RemoveByData(T data)
            {
                var current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                            {
                                tail = previous;
                            }
                        }
                        else
                        {
                            head = head.Next;

                            if (head == null)
                            {
                                tail = null;
                            }
                        }
                        count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }
                return false;
            }

            /// <summary>
            /// Deletes an element from the selected position.
            /// </summary>
            /// <param name="number">Position of the element which will be deleted from the linked list.</param>
            /// <returns>Indicates whether the removal was successful.</returns>
            public bool RemoveByNumber(int number)
            {
                if (number > count || number < 0)
                {
                    Console.WriteLine("Entered wrong value!");
                    return false;
                }

                var current = head;
                Node<T> previous = null;

                for (int i = 1; i < number; i++)
                {
                    previous = current;
                    current = current.Next;
                }
                if (previous != null)
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        tail = previous;
                    }
                }
                else
                {
                    head = head.Next;

                    if (head == null)
                    {
                        tail = null;
                    }
                }
                count--;

                return true;
            }

            /// <summary>
            /// Gets the data from the element with selected position.
            /// </summary>
            /// <param name="number">The position of the element which will be deleted from the linked list.</param>
            /// <returns>Data from the element with selected position.</returns>
            public T GetData(int number)
            {
                if (number > count || number < 0)
                {
                    Console.WriteLine("Entered wrong value");
                    return default;
                }

                var current = head;

                for (int i = 1; i < number; i++)
                {
                    current = current.Next;
                }

                return current.Data;
            }

            /// <summary>
            /// Returns the current amount of elements within the linked list.
            /// </summary>
            /// <returns>Current amount of elements within a linked list.</returns>
            public int Count => count;

            /// <summary>
            /// Checks whether the linked list is empty or not.
            /// </summary>
            /// <returns>Indicates whether the list is empty or not.</returns>
            public bool IsEmpty => count == 0;

            /// <summary>
            /// Clears the linked list.
            /// </summary>
            public void Clear()
            {
                Console.WriteLine("Done!");
                head = null;
                tail = null;
                count = 0;
            }

            /// <summary>
            /// Checks whether the linked list contains an element with selected data or not.
            /// </summary>
            /// <param name="data">Data which presence in the linked list will be checked.</param>
            /// <returns>Indicates whether the selected data is present in the linked list.</returns>
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            /// <summary>
            /// Realiztion of IEnumerable interface.
            /// </summary>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            /// <summary>
            /// Realiztion of IEnumerable interface.
            /// </summary>
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                var current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Size of the hash table.
        /// </summary>
        private int size;

        /// <summary>
        /// Load factor (if > 1, forces a resize of the hash table).
        /// </summary>
        private float loadFactor;

        /// <summary>
        /// Current amounts of elements within the hash table.
        /// </summary>
        private int amountOfElements;

        /// <summary>
        /// Elements of the hash table.
        /// </summary>
        private LinkedList<string>[] buckets;

        /// <summary>
        /// Hash table constructor.
        /// </summary>
        public HashTable()
        {
            size = 10;
            InitializeBuckets();
        }

        /// <summary>
        /// Initializes buckets within the array.
        /// </summary>
        private void InitializeBuckets()
        {
            buckets = new LinkedList<string>[size];
            for (int i = 0; i < size; ++i)
            {
                buckets[i] = new LinkedList<string>();
            }
        }

        /// <summary>
        /// Doubles the size of a hash table.
        /// </summary>
        private void ReSize()
        {
            var tempList = new LinkedList<string>();
            foreach (var list in buckets)
            {
                while (!list.IsEmpty)
                {
                    var value = list.GetData(1);
                    list.RemoveByNumber(1);
                    tempList.AddByNumber(1, value);
                }
            }

            size *= 2;
            InitializeBuckets();

            while (!tempList.IsEmpty)
            {
                Add(tempList.GetData(1));
                tempList.RemoveByNumber(1);
            }
        }

        /// <summary>
        /// Calculates the hash from the string.
        /// </summary>
        /// <param name="data">String from which hash will be calculated.</param>
        /// <returns></returns>
        private int HashFunction(string data)
        {
            int result = 0;
            foreach (var symbol in data)
            {
                result = (result * 3 + symbol) % size;
            }
            return result;
        }


        /// <summary>
        /// Adds the hash of a string to the hash table.
        /// </summary>
        /// <param name="data">String which hash will be added to the hash table.</param>
        private void Add(string data)
        {
            var hash = HashFunction(data);
            buckets[hash].AddByNumber(1, data);
        }

        /// <summary>
        /// Adds the hash of a string to the hash table and resizes the hash table if needed.
        /// </summary>
        /// <param name="data">String which hash will be added to the hash table.</param>
        public void AddData(string data)
        {
            Add(data);
            amountOfElements++;
            loadFactor = (float)amountOfElements / size;

            if (loadFactor > 1)
            {
                ReSize();
            }
        }

        /// <summary>
        /// Deletes the selected string from the hash table.
        /// </summary>
        /// <param name="data">String which will be removed.</param>
        /// <returns>Indicates whether removal was successful or not.</returns>
        public bool DeleteData(string data)
        {
            var hash = HashFunction(data);
            var valueDeleted = buckets[hash].RemoveByData(data);
            if (valueDeleted)
            {
                amountOfElements--;
                loadFactor = ((float)amountOfElements / size);
            }
            return valueDeleted;
        }

        /// <summary>
        /// Checks whether the hash table has the selected string or not.
        /// </summary>
        /// <param name="data">String to check.</param>
        /// <returns>Indicates whether the string is present in the hash table or not.</returns>
        public bool HashContains(string data)
        {
            var hash = HashFunction(data);
            return buckets[hash].Contains(data);
        }

        /// <summary>
        /// Clears the hash table.
        /// </summary>
        public void Clear()
        {
            size = 10;
            amountOfElements = 0;
            loadFactor = 0;
            InitializeBuckets();
        }
    }
}