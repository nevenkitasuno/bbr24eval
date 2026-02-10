public abstract class General { }
public abstract class Any : General { }

public interface IAddable<T>
{
    T Add(T other);
}

public sealed class Vector<T> : Any, IAddable<Vector<T>>
    where T : General, IAddable<T>
{
    private T[] _data;
    public int Length => _data.Length;

    public Vector(params T[] data) => _data = data ?? throw new ArgumentNullException(nameof(data));
    public T this[int i] => _data[i];

    public Vector<T>? Add(Vector<T> other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        if (Length != other.Length) return null;

        var res = new T[Length];
        for (int i = 0; i < Length; i++)
            res[i] = _data[i].Add(other._data[i]);

        return new Vector<T>(res);
    }
}

// Реализовал поддержку сложения произвольных типов с помощью интерфейса

// Сложение Vector<Vector<Vector<T>>> будет работать корректно,
// поскольку сам Vector подходит под заданыне в нём же ограничения обобщений
