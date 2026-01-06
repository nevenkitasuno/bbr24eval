public abstract class LinkedList<T>
{
    public const int GET_NIL = 0;
    public const int GET_OK  = 1;
    public const int GET_ERR = 2;

    public const int PUT_NIL = 0;
    public const int PUT_OK  = 1;
    public const int PUT_ERR = 2;

    public const int REMOVE_NIL = 0;
    public const int REMOVE_OK  = 1;
    public const int REMOVE_ERR = 2;

    protected LinkedList() { }

    // ===== Команды =====

    // предусловие: список не пуст
    // постусловие: курсор установлен на первый элемент
    public abstract void Head();

    // предусловие: список не пуст
    // постусловие: курсор установлен на последний элемент
    public abstract void Tail();

    // предусловие:
    //  - список не пуст
    //  - курсор не на последнем элементе
    // постусловие: курсор смещён вправо
    public abstract void Right();

    // предусловие: список не пуст
    // постусловие: справа от текущего элемента добавлен новый элемент
    public abstract void PutRight(T value);

    // предусловие: список не пуст
    // постусловие: слева от текущего элемента добавлен новый элемент
    public abstract void PutLeft(T value);

    // предусловие: список пуст
    // постусловие: добавлен единственный элемент, курсор указывает на него
    public abstract void AddToEmpty(T value);

    // постусловие: элемент добавлен в хвост
    public abstract void AddTail(T value);

    // предусловие: список не пуст
    // постусловие: значение текущего элемента заменено
    public abstract void Replace(T value);

    // предусловие: список не пуст
    // постусловие:
    //  - текущий элемент удалён
    //  - если в списке более одного элемента,
    //    курсор указывает на другой существующий элемент
    public abstract void Remove();

    // постусловие: из списка удалены все элементы со значением value
    public abstract void RemoveAll(T value);

    // постусловие: список очищен, курсор не установлен
    public abstract void Clear();

    // ===== Запросы =====
    // предусловие: список не пуст
    public abstract T Get();

    // количество элементов в списке
    public abstract int Size();

    // находится ли курсор на первом элементе
    public abstract bool IsHead();

    // находится ли курсор на последнем элементе
    public abstract bool IsTail();

    // установлен ли курсор (список не пуст)
    public abstract bool IsValue();

    // предусловие:
    //  - список не пуст
    //  - в списке есть элемент со значением value
    // постусловие:
    //  - курсор установлен на следующий элемент
    //    со значением value (от текущего)
    public abstract void Find(T value);

    public abstract int GetGetStatus();
    public abstract int GetPutStatus();
    public abstract int GetRemoveStatus();
}