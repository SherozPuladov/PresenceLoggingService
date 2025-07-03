namespace PresenceLoggingService.Models;

public class OperationResult<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public Exception? Exception { get; init; }
    
    public static OperationResult<T> Ok(T data) => new() {Success = true, Data = data};
    
    public static OperationResult<T> Error(Exception exception) => new() {Success = false, Exception = exception};
}