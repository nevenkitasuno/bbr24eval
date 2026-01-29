// Во время компиляции неизвестно какие конкретные типы будут переданы в конструктор,
// это определяется динамически во время исполнения
public class PersonsService(EmployeeAuthorizationService authorizationService, IPersonsServiceClient personsServiceClient, OrganizationService organizationService, IMemoryCache cache, ILogger<PersonsService> logger)
{
    private async ValueTask<Guid> ResolvePersonDirectoryId(Guid organizationId, ICurrentUser user)
    {
        // Тип у которого вызывается метод RequireId() 
        // определяется динамически во время исполнения,
        // может быть любой тип удовлетворяющий интерфейсу ICurrentUser
        var cacheKey = $"user:directoryId:{user.RequireId()}";

        // ...
    }
}
