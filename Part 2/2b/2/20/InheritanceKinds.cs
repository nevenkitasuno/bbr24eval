// Наследования вариаций

class Human
{
    public virtual string Greet(string name) => $"Saluton, {name}.";
}

class FrenchSpeaker : Human
{
    public override string Greet(string name) => $"Bonjour, {name}!";
}

// Наследование с конкретизацией

abstract class Shape
{
    public abstract double Area();
}

class Circle : Shape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;

    public override double Area() => Math.PI * Radius * Radius;
}

// Структурное наследование

class SomeCards : IEnumerable
{
    string[] days = { "Jack", "Queen", "King", "Ace" };
    public IEnumerator GetEnumerator() => days.GetEnumerator();
}
