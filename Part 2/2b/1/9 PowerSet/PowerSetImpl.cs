// При условии изменения table в PowerSetATD из private на protected

public class PowerSetImpl<T> : PowerSetATD<T>
{
    public PowerSetImpl(int capacity) : base(capacity) { }
    
    public override PowerSetATD<T> Intersection(PowerSetATD<T> other)
    {
        var result = new PowerSetImpl<T>(Capacity());
        if (other is PowerSetImpl<T> o)
        {
            foreach (var item in table)
            {
                if (o.table.Contains(item))
                    result.Add(item);
            }
        }
        return result;
    }

    public override PowerSetATD<T> Union(PowerSetATD<T> other)
    {
        var result = new PowerSetImpl<T>(Capacity());
        foreach (var item in table) result.Add(item);
        if (other is PowerSetImpl<T> o)
        {
            foreach (var item in o.table) result.Add(item);
        }
        return result;
    }

    public override PowerSetATD<T> Difference(PowerSetATD<T> other)
    {
        var result = new PowerSetImpl<T>(Capacity());
        foreach (var item in table)
        {
            if (!(other is PowerSetImpl<T> o) || !o.table.Contains(item))
                result.Add(item);
        }
        return result;
    }

    public override bool IsSubset(PowerSetATD<T> other)
    {
        if (other is PowerSetImpl<T> o)
        {
            foreach (var item in o.table)
            {
                if (!table.Contains(item)) return false;
            }
            return true;
        }
        return false;
    }
}
