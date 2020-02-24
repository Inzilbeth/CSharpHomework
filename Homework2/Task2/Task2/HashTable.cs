using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class HashTable
    { 
        public class LinkedList<T> : IEnumerable<T>
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

            // Головной/первый элемент.
            private Node<T> head;

            // Последний/хвостовой элемент.
            private Node<T> tail;

            // Количество элементов в списке.
            private int count;

            // Добавление элемента по номеру.
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

            // Удаление элемента по значению.
            public bool RemoveByData(T data)
            {
                var current = head;
                Node<T> previous = null;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце:
                        if (previous != null)
                        {
                            // Убираем узел current, теперь previous ссылается не на current, а на current.Next.
                            previous.Next = current.Next;

                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail.
                            if (current.Next == null)
                            {
                                tail = previous;
                            }
                        }
                        else
                        {
                            // Eсли удаляется первый элемент
                            // переустанавливаем значение head.
                            head = head.Next;

                            // Eсли после удаления список пуст, сбрасываем tail.
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

            // Удаление элемента по номеру.
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
                    // Убираем узел current, теперь previous ссылается не на current, а на current.Next.
                    previous.Next = current.Next;

                    // Если current.Next не установлен, значит узел последний,
                    // изменяем переменную tail.
                    if (current.Next == null)
                    {
                        tail = previous;
                    }
                }
                else
                {
                    // Eсли удаляется первый элемент
                    // переустанавливаем значение head.
                    head = head.Next;

                    // Eсли после удаления список пуст, сбрасываем tail.
                    if (head == null)
                    {
                        tail = null;
                    }
                }
                count--;

                return true;
            }

            // Получение значения по номеру.
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

            // Количество элементов.
            public int Count => count;

            // Провекрка на пустоту.
            public bool IsEmpty => count == 0;

            // Очистка списка.
            public void Clear()
            {
                Console.WriteLine("Done!");
                head = null;
                tail = null;
                count = 0;
            }

            // Проверка на содержание списком элемента.
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

            // Реализация интерфейса IEnumerable.
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

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

        private int size;
        private float loadFactor;
        private int amountOfElements;
        private LinkedList<string>[] buckets;

        public HashTable()
        {
            size = 10;
            InitializeBuckets();
        }

        private void InitializeBuckets()
        {
            buckets = new LinkedList<string>[size];
            for (int i = 0; i < size; ++i)
            {
                buckets[i] = new LinkedList<string>();
            }
        }

        private void ReSize()
        {
            var tempList = new LinkedList<string>();
            foreach (var list in buckets)
            {
                while (!list.IsEmpty)
                {
                    var value = list.GetData(1);
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

        private int HashFunction(string data)
        {
            int result = 0;
            foreach (var symbol in data)
            {
                result = (result + symbol) % size;
            }
            return result;
        }

        private void Add(string data)
        {
            var hash = HashFunction(data);
            buckets[hash].AddByNumber(1, data);
        }

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

        public bool HashContains(string data)
        {
            var hash = HashFunction(data);
            return buckets[hash].Contains(data);
        }

        public void Clear()
        {
            size = 10;
            amountOfElements = 0;
            loadFactor = 0;
            InitializeBuckets();
        }
    }
}