namespace DomainCommons.ResponseTypes;

public class ServiceResponse<T>
{
    public T? Data { get; set; }

    public string Message { get; set; } = string.Empty;
}