public abstract class General
{
    // Shallow Copy уже есть в C# через оператор =
    public abstract void DeepCopy(General from);
    public General Clone()
    {
        var clone = new General();
        clone.DeepCopy(this);
        return clone;
    }
    // Shallow Equals уже есть в C# через оператор ==
    public abstract void DeepEquals(General from);
    // Сериализация уже есть в C# через ToString
    public abstract General FromString(string from);
    public bool IsA<T>() => this is T;
    public Type RealType() => GetType();
}

public abstract class Any : General { }
