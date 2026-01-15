public class Manager
{
    public string Name { get; }

    protected Manager(string name)
    {
        Name = name;
    }

    public void StartMeeting()
    {
        Console.WriteLine($"Менеджер {Name} начинает собрание.");
    }
}

// Расширение класса-родителя: работник это более общий случай менеджера
public abstract class Employee : Manager
{
    protected Employee(string name) : base(name) { }

    public override void StartMeeting()
    {
        Console.WriteLine($"Сотрудник {Name} начинает собрание.");
    }

    public void TakeSickLeave()
    {
        Console.WriteLine($"Сотрудник {Name} вышел на большничный.");
    }
}

// Специализация класса-родителя: менеджер по продажам это более специализированный случай менеджера
public class SalesManager : Manager
{
    public SalesManager(string name) : base(name)
    {
        batchesSold = 0;
    }

    private int batchesSold;

    public override void StartMeeting()
    {
        Console.WriteLine($"Менеджер отдела продаж {Name} начинает собрание.");
    }

    public void SellBatch()
    {
        batchesSold += 1;
    }
}