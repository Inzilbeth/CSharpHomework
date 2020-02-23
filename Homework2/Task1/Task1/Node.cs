using System;
using System.Collections.Generic;
using System.Text;

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
}
