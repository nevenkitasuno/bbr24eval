public abstract class PowerSetATD<T> : HashTableATD<T>
{
    // ===== Конструктор =====
    // предусловие: capacity > 0
    // постусловие: создано пустое множество с ёмкостью capacity
    protected PowerSetATD(int capacity) : base(capacity) { }

    // ===== Запросы =====

    public abstract PowerSetATD<T> Intersection(PowerSetATD<T> other);

    public abstract PowerSetATD<T> Union(PowerSetATD<T> other);

    public abstract PowerSetATD<T> Difference(PowerSetATD<T> other);

    public abstract bool IsSubset(PowerSetATD<T> other);
}
