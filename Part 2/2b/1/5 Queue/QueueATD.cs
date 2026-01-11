public abstract class QueueATD<T>
{
    // ===== статусы =====
    public const int NIL = 0;
    public const int OK = 1;
    public const int ERR = 2;

    // ===== конструкторы =====

    // постусловие: создана пустая очередь
    protected QueueATD() { }

    // ====== команды ======

    // постусловия:
    //  - в начало очереди добавлен элемент со значением item
    //  - количество элементов очереди увеличено на 1
    public abstract void Enqueue(T item);

    // предусловие: очередь не пуста
    // постусловия:
    //  - из очереди удалён последний элемент
    //  - количество элементов очереди уменьшено на 1
    public abstract void Dequeue();

    // ====== запросы ======

    // предусловие: очередь не пуста
    public abstract T Peek();

    public abstract int Size();

    // ====== запросы статусов ======
    // (в комментариях возможные значения статусов)
    
    public abstract int GetDequeueStatus(); // метод не вызывался; успешно; очередь пуста
    public abstract int GetPeekStatus(); // метод не вызывался; успешно; очередь пуста
}