// Имплементация будет как в занятии по алгоритмам но без публичных Hash1 и Hash2

public abstract class BloomFilterATD<T>
{
    // ===== Конструктор =====
    // постусловие: создан пустой фильтр Блюма
    protected BloomFilterATD(int size) { }

    // ===== Команды =====

    // постусловие: элемент value добавлен в фильтр
    public abstract void Add(T value);

    // ===== Запросы =====

    public abstract bool IsValue(T value); // проверяет, есть ли value в фильтре (может быть ложноположительное с вероятностью)
}
