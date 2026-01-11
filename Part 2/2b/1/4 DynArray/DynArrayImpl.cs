public class DynArrayImpl<T> : DynArrayATD<T>
{
    private T[] data;
    private int size;

    private int insertStatus;
    private int removeStatus;
    private int getItemStatus;

    private const int DEFAULT_CAPACITY = 16;

    public DynArrayImpl()
    {
        data = new T[DEFAULT_CAPACITY];
        size = 0;

        insertStatus = NIL;
        removeStatus = NIL;
        getItemStatus = NIL;
    }


    public override void Insert(T item, int position)
    {
        if (position < 0 || position > size)
        {
            insertStatus = ERR;
            return;
        }

        EnsureCapacity(size + 1);

        for (int i = size; i > position; i--)
            data[i] = data[i - 1];

        data[position] = item;
        size++;

        insertStatus = OK;
    }

    public override void Remove(int position)
    {
        if (position < 0 || position >= size)
        {
            removeStatus = ERR;
            return;
        }

        for (int i = position; i < size - 1; i++)
            data[i] = data[i + 1];

        data[size - 1] = default!;
        size--;

        removeStatus = OK;
    }

    public override T GetItem(int position)
    {
        if (position < 0 || position >= size)
        {
            getItemStatus = ERR;
            return default!;
        }

        getItemStatus = OK;
        return data[position];
    }

    public override int Size()
    {
        return size;
    }

    public override int GetInsertStatus()
    {
        return insertStatus;
    }

    public override int GetRemoveStatus()
    {
        return removeStatus;
    }

    public override int GetGetItemStatus()
    {
        return getItemStatus;
    }

    private void EnsureCapacity(int requiredSize)
    {
        if (requiredSize <= data.Length)
            return;

        int newCapacity = data.Length * 2;
        if (newCapacity < requiredSize)
            newCapacity = requiredSize;

        var newData = new T[newCapacity];
        Array.Copy(data, newData, size);

        data = newData;
    }
}
