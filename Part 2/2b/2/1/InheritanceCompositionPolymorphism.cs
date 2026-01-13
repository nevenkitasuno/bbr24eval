using System;

abstract class Animal
{
    public string Name { get; }

    protected Animal(string name)
    {
        Name = name;
    }

    public abstract void MakeSound();
}

// Наследование – Собака является (is a) Животным
class Dog : Animal
{
    protected Dog(string name) : base(name) { }

    public static Dog FromName(string name) => new Dog(name);

    // Переопределение реализации метода класса-предка
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Woof!");
    }
}

class Cat : Animal
{
    protected Cat(string name) : base(name) { }

    public static Cat FromName(string name) => new Cat(name);

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }
}

class Collar
{
    public string Color { get; }

    private Collar(string color)
    {
        Color = color;
    }

    public static Collar FromColor(string color) => new Collar(color);
}

class PetDog : Dog
{
    // Композиция – Домашняя Собака имеет (has a) Ошейник
    public Collar Collar { get; }

    protected PetDog(string name, Collar collar) : base(name)
    {
        Collar = collar;
    }

    public static PetDog Create(string name, Collar collar) => new PetDog(name, collar);

    // Класс Домашняя Собака не содержит логику MakeSound, но повторно использует её из класса-предка Собака
}

class Program
{
    static void Main()
    {
        Animal[] animals =
        {
            Dog.FromName("Rex"),
            Cat.FromName("Murka"),
            PetDog.Create("Buddy", Collar.FromColor("Red"))
        };

        // Полиморфизм – объекты разных классов принимаются за объекты общего класса-предка
        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}
