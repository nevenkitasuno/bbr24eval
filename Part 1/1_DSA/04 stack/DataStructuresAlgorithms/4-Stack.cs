using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAlgorithms
{
    public class Exercises
    {
        // Ex 4
        public static bool AreParenthesesBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in parentheses)
            {
                if (c == ')' && stack.Size() == 0) return false;

                if (c == '(') stack.Push(c);
                else if (c == ')') stack.Pop();
            }
            return stack.Size() == 0;
        }

        public Stack<char> ReadExpression(string expression)
        {
            Stack<char> res = new Stack<char>();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                res.Push(expression[i]);
                i--; // skip whitespaces
            }

            // expression.Split(' ').ToList().ForEach(x => res.Push(x[0]));

            return res;
        }

        // Ex 5
        public int PostfixCalc(string expression)
        {
            Stack<char> expr = ReadExpression(expression);
            Stack<int> result = new Stack<int>();

            char c;
            int a, b;

            while (expr.Size() > 0)
            {
                c = expr.Pop();

                if (c == '=') return result.Pop();

                if ('0' <= c && c <= '9')
                {
                    result.Push(c - '0');
                    continue;
                }

                a = result.Pop();
                b = result.Pop();

                switch (c)
                {
                    case '+':
                        result.Push(a + b); break;
                    case '-':
                        result.Push(b - a); break;
                    case '*':
                        result.Push(a * b); break;
                    case '/':
                        result.Push(b / a); break;
                }
            }

            return result.Pop();
        }
    }

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

    // Ex 2
    public class StackHead<T> : Stack<T>
    {
        public new T Pop()
        {
            if (Elements.Count == 0) return default;
            T val = Elements.First.Value;
            Elements.RemoveLast();
            return val;
        }

        public new void Push(T val)
        {
            Elements.AddFirst(val);
        }

        public new T Peek()
        {
            if (Elements.Count == 0) return default; // null, если стек пустой
            return Elements.First.Value;
        }
    }
}

