public abstract class General
{
    // ...
    public static void AssignmentAttempt(
            ref General target,
            General source)
        {
            target = source as General;
        }
}

public abstract class Any : General
{
    public static void AssignmentAttempt(
            ref Any target,
            General source)
        {
            target = source as Any;
        }
}
