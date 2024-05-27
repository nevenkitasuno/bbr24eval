using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Exercises
    {
        public static bool IsPalindrome(string str)
        {
            Deque<char> dq = new Deque<char>(str.ToCharArray());

            while (dq.Size() > 1)
            {
                if (dq.RemoveFront()!= dq.RemoveTail())
                    return false;
            }
            return true;
        }
    }
    // double-ended queue
    public class Deque<T>
    {
        private MyNode<T> _head;
        private MyNode<T> _tail;
        private int _count;

        public Deque()   
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public Deque(IEnumerable<T> source) : this()
        {
            foreach (T item in source) AddTail(item);
        }

        public void AddFront(T item)
        {
            MyNode<T> nodeToInsert = new MyNode<T>(item)
            {
                next = _head,
                prev = null
            };
            _head = nodeToInsert;
            if (_head.next == null)
                _tail = _head;
            _count++;
        }

        public void AddTail(T item)
        {
            MyNode<T> nodeToAdd = new MyNode<T>(item);
            if (_head == null)
            {
                _head = nodeToAdd;
                _head.next = null;
                _head.prev = null;
            }
            else
            {
                _tail.next = nodeToAdd;
                nodeToAdd.prev = _tail;
            }
            _tail = nodeToAdd;
            _count++;
        }

        public T RemoveFront()
        {
            if (_head == null) return default;

            T res = _head.value;
            if (_head.next == null) _tail = null;
            _head = _head.next;
            if (_head != null) _head.prev = null;
            _count--;
            return res;
        }

        public T RemoveTail()
        {
            if (_head == null) return default;

            T res = _tail.value;
            _tail = _tail.prev;
            if (_tail == null) _head = null;
            else _tail.next = null;
            _count--;
            return res;
        }

        public int Size() => _count;
    }
    public class MyNode<T>
    {
        public T value;
        public MyNode<T> next;
        public MyNode<T> prev;
        public MyNode(T _value) { value = _value; }
    }
}
