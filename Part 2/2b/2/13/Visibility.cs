class A
{
    public void PublicPublic() { }
    protected virtual void PrivatePublic() { }
    protected void PrivatePrivate() { }
}

class B : A
{
    // PublicPublic унаследован

    // В C# при наследовании нельзя делать доступ более строгим

    // При override можно сделать доступ менее строгим
    public override void PrivatePublic() { }

    // PrivatePrivate унаследован (используется ключевое слово protected)
}
