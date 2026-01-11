public class QueueImpl<T> : QueueATD<T>
{
    private readonly LinkedList<T> list;

    private int dequeueStatus;
    private int peekStatus;

    public QueueImpl()
    {
        list = new LinkedList<T>();
        dequeueStatus = NIL;
        peekStatus = NIL;
    }

    public override void Enqueue(T item) => list.AddLast(item);

    public override void Dequeue()
    {
        if (list.Count == 0)
        {
            dequeueStatus = ERR;
            return;
        }

        list.RemoveFirst();
        dequeueStatus = OK;
    }

    public override T Peek()
    {
        if (list.Count == 0)
        {
            peekStatus = ERR;
            return default!;
        }

        peekStatus = OK;
        return list.First!.Value;
    }

    public override int Size() => list.Count;
    public override int GetDequeueStatus() => dequeueStatus;
    public override int GetPeekStatus() => peekStatus;
}
