using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    // Односвязный список.
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

        // Добавление элемента по значению в конец.
        public void AddByData(T data)
        {
            var node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;

            count++;
        }

        // Добавление элемента по номеру.
        public void AddByNumber(int number, T data)
        {
            if (number > count + 1)
            {
                Console.WriteLine("Entered value exceeds list size + 1!");
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
            if (number > count)
            {
                Console.WriteLine("Entered value exceeds list size!");
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
        public T GetValue(int number)
        {
            if (number > count)
            {
                Console.WriteLine("Entered value exceeds list size!");
                return default;
            }

            var current = head;

            for (int i = 1; i < number; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        // Установка значения по номеру.
        public bool SetValue(int number, T data)
        {
            if (number > count)
            {
                Console.WriteLine("Entered value exceeds list size!");
                return false;
            }

            var current = head;

            for (int i = 1; i < number; i++)
            {
                current = current.Next;
            }
            current.Data = data;
            return true;
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

        // Добвление в начало списка.
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
            {
                tail = head;
            }
            count++;
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
}
