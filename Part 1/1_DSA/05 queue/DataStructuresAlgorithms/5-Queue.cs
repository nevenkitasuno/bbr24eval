using System;
using System.Collections.Generic;

namespace DataStructuresAlgorithms
{
    public class Queue<T>
    {
        private LinkedList<T> _elements;
        public Queue() => _elements = new LinkedList<T>(); 

        // O(1)
        public void Enqueue(T item) => _elements.AddLast(item);

        // O(1)
        public T Dequeue()
        {
            if (Size() == 0) return default;
            T val = _elements.First.Value;
            _elements.RemoveFirst();
            return val;
        }

        public int Size() => _elements.Count;

        public void Rotate(int n)
        {
            while (n-- > 0) Enqueue(Dequeue());
        }
    }

    public class TwoStacksQueue<T>
    {
        private Stack<T> _elements;
        private Stack<T> _buf;

        public TwoStacksQueue()
        {
            _elements = new Stack<T>();
            _buf = new Stack<T>();
        }

        // O(1)
        public void Enqueue(T item) => _elements.Push(item);

        // O(n)
        public T Dequeue()
        {
            if (_buf.Count == 0)
            {
                while (_elements.Count > 0) _buf.Push(_elements.Pop());
            }
            return _buf.Pop();
        }

        public int Size() => _elements.Count;
    }
}

