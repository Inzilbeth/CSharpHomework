using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Task3
{
    public class StackAsArray<T> : IStack<T>, IEnumerable<T>
    {
        private T[] items;
        private int count;
        private const int n = 10;

        public StackAsArray()
        {
            items = new T[n];
        }

        public StackAsArray(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty()
            => count == 0;

        public int Count
            => count;

        public void Push(T item)
        {
            if (count == items.Length)
            {
                Resize(items.Length + 10);
            }

            items[count] = item;
            count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            T item = items[--count];
            items[count] = default;

            if (count > 0 && count < items.Length - 10)
            {
                Resize(items.Length - 10);
            }

            return item;
        }

        public T Peek()
        {
            if (!IsEmpty())
            {
                return items[count - 1];
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            
            for (int i = 0; i < count; i++)
            {
                tempItems[i] = items[i];
            }
            
            items = tempItems;
        }

        public void Clear()
        {
            items = new T[n];
            count = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }
    }
}
