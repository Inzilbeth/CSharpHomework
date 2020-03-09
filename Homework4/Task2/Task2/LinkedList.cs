using System;
using System.Collections;
using System.Collections.Generic;


namespace Task2
{
    /// <summary>
    /// Linked List class.
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
        public virtual void AddByNumber(int number, T data)
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
                throw new System.ArgumentOutOfRangeException("Entered wrong value");
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

        public string[] ReturnAllNodes()
        {
            var currentNode = head;

            if (currentNode == null)
            {
                throw new Exception("List is empty");
            }

            var allNodes = new string[count];
            for (int i = 0; i < count; i++)
            {
                allNodes[i] = Convert.ToString(currentNode.Data);
                currentNode = currentNode.Next;
            }

            return allNodes;
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
}
