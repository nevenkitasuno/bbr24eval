public abstract class HashTableATD<T>
{
    // ===== статусы =====
    public const int NIL = 0;
    public const int OK = 1;
    public const int PUT_ERR_FULL = 10;
    public const int PUT_ERR_COLLISION = 11;

    // ===== конструктор =====

    // предусловие: capacity > 0
    // постусловие: создана пустая хэш-таблица c ёмкостью capacity
    protected HashTableATD(int capacity) { }

    // ===== команды =====

    // предусловие: в таблице есть место
    // постусловие: значение value добавлено в таблицу
    public abstract void Put(T value);

    // постусловие: value удалено из таблицы
    public abstract void Remove(T value);

    // ===== запросы =====

    public abstract bool Contains(T value); // Возвращает true, если value содержится в таблице. Иначе false
    public abstract int Size();
    public abstract int Capacity();

    // ===== запросы статусов =====

    public abstract int GetPutStatus(); // метод не вызывался; успешно; в таблице нет места; не удалось вставить элемент из-за ограничений механизма разрешения коллизий
}
