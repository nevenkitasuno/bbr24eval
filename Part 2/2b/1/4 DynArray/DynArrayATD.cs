public abstract class DynArrayATD<T>
{
    // ===== статусы =====
    public const int NIL = 0;
    public const int OK = 1;
    public const int ERR = 2;

    // ===== конструкторы =====

    // постусловие: создан пустой динамический массив
    protected DynArrayATD() { }

    // ====== команды ======

    // предусловие: position <= число элементов в массиве
    // постусловия:
    //  - в массиве на позиции position элемент item
    //  - у элементов с индексом > position индекс увеличен на 1
    //  - количество элементов массива увеличено на 1
    public abstract void Insert(T item, int position);

    // предусловие: position < число элементов в массиве
    // постусловия:
    //  - у элементов с индексом > position индекс уменьшен на 1
    //  - количество элементов массива увменьшено на 1
    public abstract void Remove(int position);

    // ====== запросы ======

    // предусловие: position < число элементов в массиве
    public abstract T GetItem(int position);

    public abstract int Size();

    // ====== запросы статусов ======
    
    public abstract int GetInsertStatus();
    public abstract int GetRemoveStatus();
    public abstract int GetGetItemStatus();
}