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

public class Pickup : DeliveryMethod
{
    public override decimal CalcShipping(decimal itemsTotal) => 0m;
    public override int EstimatedDays() => 0;
}

public class Order
{
    public decimal ItemsTotal { get; set; }
    public DeliveryMethod Delivery { get; set; } = new StandardDelivery();

    public decimal TotalCost() => ItemsTotal + Delivery.CalcShipping(ItemsTotal);
    public int DeliveryDays() => Delivery.EstimatedDays();
}

class Program
{
    static void Main(string[] args)
    {
        var order = new Order { ItemsTotal = 100m, Delivery = new ExpressDelivery() };

        Console.WriteLine(order.TotalCost());    // 115
        Console.WriteLine(order.DeliveryDays()); // 1
    }
}

