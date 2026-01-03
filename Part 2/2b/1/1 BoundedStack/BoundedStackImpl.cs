namespace course2b
{
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
            popStatus = POP_NIL;
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
            popStatus = POP_NIL;
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
}