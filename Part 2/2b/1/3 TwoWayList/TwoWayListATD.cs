public abstract class ParentListATD<T>
{
    // ===== статусы =====

    public const int LIST_EMPTY = 0;
    public const int OK = 1;
    public const int ERR = 2;

    public const int FIND_NOT_FOUND = 10;

    // ===== конструктор =====

    // постусловие: создан новый пустой список
    protected ParentListATD()
    {
    }

    // ===== команды =====

    // предусловие: список не пуст
    // постусловие: курсор установлен на первый элемент
    public abstract void Head();

    // предусловие: список не пуст
    // постусловие: курсор установлен на последний элемент
    public abstract void Tail();

    // предусловие: правее курсора есть элемент
    // постусловие: курсор сдвинут вправо
    public abstract void Right();

    // предусловие: список не пуст
    // постусловие: после курсора вставлен новый элемент
    public abstract void PutRight(T value);

    // предусловие: список не пуст
    // постусловие: перед курсором вставлен новый элемент
    public abstract void PutLeft(T value);

    // предусловие: список пуст
    // постусловие: список состоит из одного элемента, курсор указывает на него
    public abstract void AddToEmpty(T value);

    // предусловие: список не пуст
    // постусловие:
    //   текущий элемент удалён,
    //   курсор смещён:
    //     вправо, если справа есть элемент,
    //     иначе, если слева есть элемент, влево,
    //     иначе не установлен
    public abstract void Remove();

    // постусловие: список очищен, курсор не установлен
    public abstract void Clear();

    // постусловие: элемент добавлен в хвост списка
    public abstract void AddTail(T value);

    // постусловие: удалены все элементы со значением value
    public abstract void RemoveAll(T value);

    // предусловие: список не пуст
    // постусловие: значение текущего элемента заменено
    public abstract void Replace(T value);

    // постусловие:
    //   курсор установлен на следующий элемент
    //   со значением value, если такой найден
    public abstract void Find(T value);

    // ===== запросы =====

    // предусловие: список не пуст
    public abstract T Get();

    public abstract bool IsHead();
    public abstract bool IsTail();
    public abstract bool IsValue();
    public abstract int Size();

    // ===== запросы статусов =====
    // (в комментариях возможные значения статусов)

    public abstract int GetHeadStatus(); // успешно; список пуст
    public abstract int GetTailStatus(); // успешно; список пуст
    public abstract int GetRightStatus(); // успешно; правее нет элемента
    public abstract int GetPutRightStatus(); // успешно; список пуст
    public abstract int GetPutLeftStatus(); // успешно; список пуст
    public abstract int GetAddToEmptyStatus(); // успешно
    public abstract int GetRemoveStatus(); // успешно; список пуст
    public abstract int GetReplaceStatus(); // успешно; список пуст
    public abstract int GetFindStatus(); // следующий найден; следующий не найден; список пуст
    public abstract int GetGetStatus(); // успешно; список пуст
}

public abstract class LinkedListATD<T> : ParentListATD<T>
{
    protected LinkedListATD() : base()
    {
    }
}

public abstract class TwoWayListATD<T> : ParentListATD<T>
{
    // ===== команды =====

    // предусловие: левее курсора есть элемент
    // постусловие: курсор сдвинут влево
    public abstract void Left();

    // ===== запросы статусов =====

    // успешно; левее нет элемента
    public abstract int GetLeftStatus();

    protected TwoWayListATD() : base()
    {
    }
}
