public class HashTableImpl<T> : HashTableATD<T>
{
    private readonly HashSet<T> table;
    private readonly int capacity;

    private int putStatus = NIL;

    public HashTableImpl(int capacity) : base(capacity)
    {
        this.capacity = capacity;
        table = new HashSet<T>();
    }

    public override void Put(T value)
    {
        if (table.Contains(value))
        {
            putStatus = OK;
            return;
        }

        if (table.Count >= capacity)
        {
            putStatus = PUT_ERR_FULL;
            return;
        }

        table.Add(value);
        putStatus = OK;
    }

    public override void Remove(T value) => table.Remove(value);

    // ===== запросы =====

    public override bool Contains(T value) => table.Contains(value);
    public override int Size() => table.Count;
    public override int Capacity() => capacity;

    // ===== запросы статусов =====

    public override int GetPutStatus() => putStatus;
}
