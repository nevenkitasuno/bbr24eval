public class TwoWayListImpl<T> : TwoWayListATD<T>
{
    private class Node
    {
        public T Value;
        public Node? Next;
        public Node? Prev;

        public Node(T value)
        {
            Value = value;
        }
    }

    public const int LIST_EMPTY = 0;
    public const int OK = 1;
    public const int ERR = 2;
    public const int FIND_NOT_FOUND = 10;

    private Node? head;
    private Node? tail;
    private Node? cursor;
    private int size;

    private int headStatus;
    private int tailStatus;
    private int rightStatus;
    private int leftStatus;
    private int putRightStatus;
    private int putLeftStatus;
    private int addToEmptyStatus;
    private int removeStatus;
    private int replaceStatus;
    private int findStatus;
    private int getStatus;

    public TwoWayListImpl()
    {
        Clear();
    }


    public override void Head()
    {
        if (size == 0)
        {
            headStatus = LIST_EMPTY;
            return;
        }

        cursor = head;
        headStatus = OK;
    }

    public override void Tail()
    {
        if (size == 0)
        {
            tailStatus = LIST_EMPTY;
            return;
        }

        cursor = tail;
        tailStatus = OK;
    }

    public override void Right()
    {
        if (cursor!.Next == null)
        {
            rightStatus = ERR;
            return;
        }

        cursor = cursor.Next;
        rightStatus = OK;
    }

    public override void Left()
    {
        if (cursor!.Prev == null)
        {
            leftStatus = ERR;
            return;
        }

        cursor = cursor.Prev;
        leftStatus = OK;
    }

    public override void PutRight(T value)
    {
        if (size == 0)
        {
            putRightStatus = LIST_EMPTY;
            return;
        }

        var node = new Node(value)
        {
            Prev = cursor,
            Next = cursor!.Next
        };

        if (cursor.Next != null)
            cursor.Next.Prev = node;
        else
            tail = node;

        cursor.Next = node;
        size++;

        putRightStatus = OK;
    }

    public override void PutLeft(T value)
    {
        if (size == 0)
        {
            putLeftStatus = LIST_EMPTY;
            return;
        }

        var node = new Node(value)
        {
            Next = cursor,
            Prev = cursor!.Prev
        };

        if (cursor.Prev != null)
            cursor.Prev.Next = node;
        else
            head = node;

        cursor.Prev = node;
        size++;

        putLeftStatus = OK;
    }

    public override void AddToEmpty(T value)
    {
        if (size != 0)
        {
            addToEmptyStatus = ERR;
            return;
        }

        var node = new Node(value);
        head = tail = cursor = node;
        size = 1;

        addToEmptyStatus = OK;
    }

    public override void AddTail(T value)
    {
        if (size == 0)
        {
            AddToEmpty(value);
            return;
        }

        var node = new Node(value)
        {
            Prev = tail
        };

        tail!.Next = node;
        tail = node;
        size++;
    }

    public override void Remove()
    {
        if (size == 0)
        {
            removeStatus = LIST_EMPTY;
            return;
        }

        var next = cursor!.Next;
        var prev = cursor.Prev;

        if (prev != null)
            prev.Next = next;
        else
            head = next;

        if (next != null)
            next.Prev = prev;
        else
            tail = prev;

        cursor = next ?? prev;
        size--;

        removeStatus = OK;
    }

    public override void RemoveAll(T value)
    {
        var node = head;

        while (node != null)
        {
            var next = node.Next;

            if (Equals(node.Value, value))
            {
                if (node.Prev != null)
                    node.Prev.Next = node.Next;
                else
                    head = node.Next;

                if (node.Next != null)
                    node.Next.Prev = node.Prev;
                else
                    tail = node.Prev;

                if (cursor == node)
                    cursor = node.Next ?? node.Prev;

                size--;
            }

            node = next;
        }
    }

    public override void Replace(T value)
    {
        if (size == 0)
        {
            replaceStatus = LIST_EMPTY;
            return;
        }

        cursor!.Value = value;
        replaceStatus = OK;
    }

    public override void Find(T value)
    {
        if (size == 0)
        {
            findStatus = LIST_EMPTY;
            return;
        }

        var node = cursor!.Next;

        while (node != null)
        {
            if (Equals(node.Value, value))
            {
                cursor = node;
                findStatus = OK;
                return;
            }
            node = node.Next;
        }

        findStatus = FIND_NOT_FOUND;
    }

    public override void Clear()
    {
        head = tail = cursor = null;
        size = 0;

        headStatus = tailStatus = rightStatus = leftStatus =
        putRightStatus = putLeftStatus = addToEmptyStatus =
        removeStatus = replaceStatus = findStatus = getStatus = LIST_EMPTY;
    }


    public override T Get()
    {
        if (size == 0)
        {
            getStatus = LIST_EMPTY;
            return default!;
        }

        getStatus = OK;
        return cursor!.Value;
    }

    public override bool IsHead() => cursor != null && cursor == head;
    public override bool IsTail() => cursor != null && cursor == tail;
    public override bool IsValue() => cursor != null;
    public override int Size() => size;


    public override int GetHeadStatus() => headStatus;
    public override int GetTailStatus() => tailStatus;
    public override int GetRightStatus() => rightStatus;
    public override int GetLeftStatus() => leftStatus;
    public override int GetPutRightStatus() => putRightStatus;
    public override int GetPutLeftStatus() => putLeftStatus;
    public override int GetAddToEmptyStatus() => addToEmptyStatus;
    public override int GetRemoveStatus() => removeStatus;
    public override int GetReplaceStatus() => replaceStatus;
    public override int GetFindStatus() => findStatus;
    public override int GetGetStatus() => getStatus;
}
