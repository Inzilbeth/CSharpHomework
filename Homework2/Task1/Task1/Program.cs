using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    // Элемент списка.
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    // Односвязный список.
    public class LinkedList<T> : IEnumerable<T>  
    {
        // Головной/первый элемент.
        Node<T> head;

        // Последний/хвостовой элемент.
        Node<T> tail;

        // Количество элементов в списке.
        int count;  

        // Добавление элемента по значению в конец.
        public void AddByData(T data)
        {
            Node<T> node = new Node<T>(data);

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
            if(number > count + 1)
            {
                return;
            }
            
            Node<T> node = new Node<T>(data);
            Node<T> current = head;
            Node<T> previous = null;
            
            for (int i = 1; i < number; i++)
            {
                previous = current;
                current = current.Next;
            }
            
            if(number == 1)
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
            Node<T> current = head;
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
                            tail = previous;
                    }
                    else
                    {
                        // Eсли удаляется первый элемент
                        // переустанавливаем значение head.
                        head = head.Next;

                        // Eсли после удаления список пуст, сбрасываем tail.
                        if (head == null)
                            tail = null;
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
            if(number > count)
            {
                return false;
            }

            Node<T> current = head;
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
                    tail = previous;
            }
            else
            {
                // Eсли удаляется первый элемент
                // переустанавливаем значение head.
                head = head.Next;

                // Eсли после удаления список пуст, сбрасываем tail.
                if (head == null)
                    tail = null;
            }
            count--;

            return true;
        }

        // Получение значения по номеру.
        public T GetValue(int number)
        {
            if (number > count)
            {
                return default(T);
            }

            Node<T> current = head;

            for (int i = 1; i < number; i++)
            {
                current = current.Next;
            }

            return current.Data; 
        }

        // Установка значения по номеру.
        public bool SetValue(int number, T data )
        {
            if (number > count)
            {
                return false;
            }

            Node<T> current = head;

            for (int i = 1; i < number; i++)
            {
                current = current.Next;
            }
            current.Data = data;
            return true;
        }

        // Количество элементов.
        public int Count { get { return count; } }

        // Провекрка на пустоту.
        public bool IsEmpty { get { return count == 0; } }

        // Очистка списка.
        public void Clear()
        {
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
                    return true;
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
                tail = head;
            count++;
        }

        // Реализация интерфейса IEnumerable.
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

    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            int command = -1;
            while (command != 0)
            {
                Console.WriteLine("Select the operation: ");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: AddByNumber");
                Console.WriteLine("2: RemoveByNumber ");
                Console.WriteLine("3: Size");
                Console.WriteLine("4: IsEmpty? ");
                Console.WriteLine("5: GetValue ");
                Console.WriteLine("6: SetValue ");
                Console.WriteLine("7: Print ");
                command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the number, then value line by line:");
                            int number = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            linkedList.AddByNumber(number, value);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the number: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            linkedList.RemoveByNumber(number);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(linkedList.Count);
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(linkedList.IsEmpty);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the number: ");
                            int number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(linkedList.GetValue(number));
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the number, then value line by line:");
                            int number = Convert.ToInt32(Console.ReadLine());
                            int value = Convert.ToInt32(Console.ReadLine());
                            linkedList.SetValue(number, value);
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Your list is: ");
                            foreach (var item in linkedList)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    default:
                        {
                            command = 0;
                            break;
                        }
                }
            }
        }
    }
}
