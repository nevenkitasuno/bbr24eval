using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public LinkedList<T> Elements;
        public Stack()
        {
            // инициализация внутреннего хранилища стека
            Elements = new LinkedList<T>();
        }

        public int Size()
        {	  
            return Elements.Count;
        }

        public T Pop()
        {
            if (Elements.Count == 0) return default; // null, если стек пустой
            T val = Elements.Last.Value;
            Elements.RemoveLast();
            return val;
        }

        public void Push(T val)
        {
            Elements.AddLast(val);
        }

        public T Peek()
        {
            if (Elements.Count == 0) return default; // null, если стек пустой
            return Elements.Last.Value;
        }
    }
}

