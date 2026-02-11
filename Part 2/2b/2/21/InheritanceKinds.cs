// Наследование реализации

class MyStack<T> : List<T>
{
    public void Push(T item) => Add(item);

    public T Pop()
    {
        if (Count == 0) return default;
        var last = this[Count - 1];
        RemoveAt(Count - 1);
        return last;
    }

    public T Peek()
    {
        if (Count == 0) return default;
        return this[Count - 1];
    }
}

// Льготное наследование

abstract class ControllerBase
{
    protected string CurrentUserId { get; private set; } = "anonymous";

    protected void SetUser(string userId) => CurrentUserId = userId;

    protected void Ok(object body) =>
        Console.WriteLine($"200 OK (user={CurrentUserId}): {body}");

    protected void BadRequest(string error) =>
        Console.WriteLine($"400 BadRequest (user={CurrentUserId}): {error}");
}

class OrdersController : ControllerBase
{
    public void GetOrder(int id)
    {
        if (id <= 0) { BadRequest("id must be positive"); return; }
        Ok(new { id, status = "placed" });
    }
}

