using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public interface IStack<T>
    {
        bool IsEmpty();

        void Push(T data);

        T Pop();

        void Clear();
    }
}

