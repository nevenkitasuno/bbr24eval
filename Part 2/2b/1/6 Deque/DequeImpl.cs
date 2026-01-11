public class DequeImpl<T> : DequeATD<T>
{
    private readonly LinkedList<T> list = new();

    private int getHeadStatus = NIL;
    private int getTailStatus = NIL;
    private int removeHeadStatus = NIL;
    private int removeTailStatus = NIL;

    public override void AddTail(T item) => list.AddLast(item);

    public override void RemoveHead()
    {
        if (list.Count == 0)
        {
            removeHeadStatus = ERR;
            return;
        }

        list.RemoveFirst();
        removeHeadStatus = OK;
    }

    public override void AddHead(T item) => list.AddFirst(item);

    public override void RemoveTail()
    {
        if (list.Count == 0)
        {
            removeTailStatus = ERR;
            return;
        }

        list.RemoveLast();
        removeTailStatus = OK;
    }

    public override int Size() => list.Count;

    public override T GetHead()
    {
        if (list.Count == 0)
        {
            getHeadStatus = ERR;
            return default!;
        }

        getHeadStatus = OK;
        return list.First!.Value;
    }

    public override T GetTail()
    {
        if (list.Count == 0)
        {
            getTailStatus = ERR;
            return default!;
        }

        getTailStatus = OK;
        return list.Last!.Value;
    }

    public override int GetGetFrontStatus() => getHeadStatus;
    public override int GetGetTailStatus() => getTailStatus;
    public override int GetRemoveFrontStatus() => removeHeadStatus;
    public override int GetRemoveTailStatus() => removeTailStatus;
}
