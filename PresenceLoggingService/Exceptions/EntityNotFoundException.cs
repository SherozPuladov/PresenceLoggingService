namespace PresenceLoggingService.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, object key) 
        : base($"Сущность {entityName} с идентификатором {key} не найдено") 
    { }
}