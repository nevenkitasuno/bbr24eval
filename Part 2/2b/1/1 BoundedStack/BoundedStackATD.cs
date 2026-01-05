namespace course2b
{
    public abstract class BoundedStackATD<T>
    {
        // ====== статусы push ======
        public const int PUSH_NIL = 0; // push ещё не вызывался
        public const int PUSH_OK = 1; // элемент добавлен
        public const int PUSH_ERR = 2; // стек переполнен

        // ====== статусы pop ======
        public const int POP_NIL = 0;  // pop ещё не вызывался
        public const int POP_OK = 1;  // элемент удалён
        public const int POP_ERR = 2;  // стек пуст

        // ====== статусы peek ======
        public const int PEEK_NIL = 0; // peek ещё не вызывался
        public const int PEEK_OK = 1; // значение получено
        public const int PEEK_ERR = 2; // стек пуст

        // ====== конструкторы ======

        // постусловие: создан пустой стек с максимальной ёмкостью capacity
        protected BoundedStackATD(int capacity) { }

        // постусловие: создан пустой стек с максимальной ёмкостью 32
        protected BoundedStackATD() { }

        // ====== команды ======

        // предусловие: стек не переполнен
        // постусловие: элемент добавлен
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
}