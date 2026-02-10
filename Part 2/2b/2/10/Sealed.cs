class General
{
    public virtual void DoWork()
    {
        Console.WriteLine("Base implementation");
    }
}

class Any : General
{
    public sealed override void DoWork()
    {
        Console.WriteLine("I'm sealed");
    }
}

class DerivedClass : Any
{
    // Не получится переопределить т.к. метод в предке sealed
    public override void DoWork()
    {
        Console.WriteLine("I'm overrided sealed method!.. Wait but...");
    }
}
