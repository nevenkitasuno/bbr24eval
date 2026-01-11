public abstract class NativeDictionaryATD<T>
{
    // ===== статусы =====
    public const int NIL = 0;
    public const int OK = 1;
    public const int ERR = 2;

    // ===== конструктор =====

    // постусловие: создан пустой словарь
    protected NativeDictionaryATD() { }

    // ===== команды =====

    // постусловия:
    //  - если key отсутствовал, добавлена новая пара (key, value)
    //  - если key присутствовал, его значение заменено на value
    public abstract void Put(string key, T value);

    // ===== запросы =====

    public abstract bool IsKey(string key); // возвращает true, если key присутствует в словаре

    // предусловие: key присутствует в словаре
    public abstract T Get(string key); // возвращает значение ключа key

    // ===== запросы статусов =====

    public abstract int GetPutStatus(); // метод не вызывался; успешно; ошибка вставки
    public abstract int GetGetStatus(); // метод не вызывался; успешно; ключ не найден
}
