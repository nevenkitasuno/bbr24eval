public abstract class ParentQueueATD<T>
{
    // ===== статусы =====
    public const int NIL = 0;
    public const int OK = 1;
    public const int ERR = 2;

    // ===== конструкторы =====

    // постусловие: создана пустая очередь
    protected ParentQueueATD() { }

    // ====== команды ======

    // постусловия:
    //  - со стороны хвоста очереди добавлен элемент со значением item
    //  - количество элементов очереди увеличено на 1
    public abstract void AddTail(T item);

    // предусловие: очередь не пуста
    // постусловия:
    //  - удалён элемент являвшийся на момент вызова головой очереди
    //  - количество элементов очереди уменьшено на 1
    public abstract void RemoveHead();

    // ====== запросы ======

    // предусловие: очередь не пуста
    public abstract T GetHead();

    public abstract int Size();

    // ====== запросы статусов ======
    // (в комментариях возможные значения статусов)
    
    public abstract int GetRemoveFrontStatus(); // метод не вызывался; успешно; очередь пуста
    public abstract int GetGetFrontStatus(); // метод не вызывался; успешно; очередь пуста
}

public abstract class QueueATD<T> : ParentQueueATD<T>
{
    protected QueueATD() : base()
    {
    }
}

public abstract class DequeATD<T> : ParentQueueATD<T>
{
    // ====== команды ======

    // постусловия:
    //  - со стороны головы очереди добавлен элемент со значением item
    //  - количество элементов очереди увеличено на 1
    public abstract void AddHead(T item);

    // предусловие: очередь не пуста
    // постусловия:
    //  - удалён элемент являвшийся на момент вызова хвостом очереди
    //  - количество элементов очереди уменьшено на 1
    public abstract void RemoveTail();

    // ====== запросы ======

    // предусловие: очередь не пуста
    public abstract T GetTail();

    protected DequeATD() : base()
    {
    }

    // ====== запросы статусов ======
    // (в комментариях возможные значения статусов)
    
    public abstract int GetRemoveTailStatus(); // метод не вызывался; успешно; очередь пуста
    public abstract int GetGetTailStatus(); // метод не вызывался; успешно; очередь пуста
}
