// ===== Полиморфизм =====

public abstract class DeliveryMethod
{
    public abstract decimal CalcShipping(decimal itemsTotal);
    public abstract int EstimatedDays();
}

public class StandardDelivery : DeliveryMethod
{
    public override decimal CalcShipping(decimal itemsTotal) => 5m;
    public override int EstimatedDays() => 5;
}

public class ExpressDelivery : DeliveryMethod
{
    public override decimal CalcShipping(decimal itemsTotal) => 15m;
    public override int EstimatedDays() => 1;
}

class Program
{
    static void Main(string[] args)
    {
        DeliveryMethod m = new StandardDelivery(); // Полиморфное присваивание
        Console.WriteLine(m.EstimatedDays()); // Полиморфный вызов

        m = new ExpressDelivery();
        Console.WriteLine(m.EstimatedDays());
    }
}

// ===== Ковариантность =====

class A { }
class B : A { }

class Factory
{
    public virtual A Create() => new A();
}

class BFactory : Factory
{
    public override B Create() => new B(); // Ковариантность
}
