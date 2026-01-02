using System;
using System.Collections.Generic;

public abstract class BoundedStackATD<T>
{
    // ====== статусы push ======
    public const int PUSH_NIL = 0; // push ещё не вызывался
    public const int PUSH_OK  = 1; // элемент добавлен
    public const int PUSH_ERR = 2; // стек переполнен

    // ====== статусы pop ======
    public const int POP_NIL = 0;  // pop ещё не вызывался
    public const int POP_OK  = 1;  // элемент удалён
    public const int POP_ERR = 2;  // стек пуст

    // ====== статусы peek ======
    public const int PEEK_NIL = 0; // peek ещё не вызывался
    public const int PEEK_OK  = 1; // значение получено
    public const int PEEK_ERR = 2; // стек пуст

    // ====== конструкторы ======

    // постусловие: создан пустой стек с максимальной ёмкостью capacity
    protected BoundedStackATD(int capacity) { }

    // постусловие: создан пустой стек с максимальной ёмкостью 32
    protected BoundedStackATD() { }

    // ====== команды ======

    // предусловие: стек не переполнен
    // постусловие: элемент добавлен
    //  - если  → элемент добавлен
    //  - иначе → состояние стека не изменяется
    public abstract void Push(T value);

    // предусловие: стек не пуст
    // постусловие: верхний элемент удалён
    public abstract void Pop();

    // постусловие: стек пуст
    public abstract void Clear();

    // ====== запросы ======

    // предусловие: стек не пуст
    public abstract T Peek();

    public abstract int Size();

    public abstract int Capacity();

    // ====== запросы статусов ======

    public abstract int GetPushStatus();
    public abstract int GetPopStatus();
    public abstract int GetPeekStatus();
}

public class BoundedStackImpl<T> : BoundedStackATD<T>
{
    // ====== скрытые поля ======
    private List<T> stack;
    private int capacity;

    private int pushStatus;
    private int popStatus;
    private int peekStatus;

    // ====== конструкторы ======

    public BoundedStackImpl(int capacity)
    {
        this.capacity = capacity > 0 ? capacity : 32;
        stack = new List<T>();

        pushStatus = PUSH_NIL;
        popStatus  = POP_NIL;
        peekStatus = PEEK_NIL;
    }

    public BoundedStackImpl() : this(32)
    {
    }

    // ====== команды ======

    public override void Push(T value)
    {
        if (stack.Count < capacity)
        {
            stack.Add(value);
            pushStatus = PUSH_OK;
        }
        else
        {
            pushStatus = PUSH_ERR;
        }
    }

    public override void Pop()
    {
        if (stack.Count > 0)
        {
            stack.RemoveAt(stack.Count - 1);
            popStatus = POP_OK;
        }
        else
        {
            popStatus = POP_ERR;
        }
    }

    public override void Clear()
    {
        stack.Clear();

        pushStatus = PUSH_NIL;
        popStatus  = POP_NIL;
        peekStatus = PEEK_NIL;
    }

    // ====== запросы ======

    public override T Peek()
    {
        if (stack.Count > 0)
        {
            peekStatus = PEEK_OK;
            return stack[stack.Count - 1];
        }
        else
        {
            peekStatus = PEEK_ERR;
            return default!;
        }
    }

    public override int Size()
    {
        return stack.Count;
    }

    public override int Capacity()
    {
        return capacity;
    }

    // ====== запросы статусов ======

    public override int GetPushStatus() => pushStatus;

    public override int GetPopStatus() => popStatus;

    public override int GetPeekStatus() => peekStatus;
}
