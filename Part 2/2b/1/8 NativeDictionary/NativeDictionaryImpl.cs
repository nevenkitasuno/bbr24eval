public class NativeDictionaryImpl<T> : NativeDictionaryATD<T>
{
    private readonly Dictionary<string, T> dictionary = new();
    private int putStatus = NIL;
    private int getStatus = NIL;

    public NativeDictionaryImpl() : base()
    {
    }

    public override void Put(string key, T value)
    {
        dictionary[key] = value;
        putStatus = OK;
    }

    public override bool IsKey(string key) => dictionary.ContainsKey(key);

    public override T Get(string key)
    {
        if (!dictionary.ContainsKey(key))
        {
            getStatus = ERR;
            return default!;
        }

        getStatus = OK;
        return dictionary[key];
    }

    public override int GetPutStatus() => putStatus;

    public override int GetGetStatus() => getStatus;
}
