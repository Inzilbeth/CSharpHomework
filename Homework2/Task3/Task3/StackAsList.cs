using System;
using System.Collections.Generic;
using System.Collections;

namespace Task3
{
    public class StackAsList<T> : IStack<T>, IEnumerable<T>
    {
        private class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }

            public T Data { get; set; }

            public Node<T> Next { get; set; }
        }

        private Node<T> head;
        private int count;

        public bool IsEmpty()
            => count == 0;

        public int Count()
            => count;
        
        public void Push(T item)
        {
            var node = new Node<T>(item);
            node.Next = head; 
            head = node;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            
            Node<T> temp = head;
            head = head.Next;
            count--;
            return temp.Data;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return head.Data;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}