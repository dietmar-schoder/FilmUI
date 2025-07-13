namespace FilmUI.DTOs;

public class Result<T>
{
    private const string ExceptionMessage = "A system error occured. We were notified of that fact and we are currently busy to resolve the problem.";

    public bool IsSuccess => !IsError && !IsException;
    public bool IsError { get; init; }
    public bool IsException { get; init; }
    public string ErrorMessage { get; init; }
    public T Data { get; init; }

    public static Result<T> Success(T data) => new() { Data = data };

    public static Result<T> Error(string message) => new() { IsError = true, ErrorMessage = message };

    public static Result<T> Exception() => new() { IsException = true, ErrorMessage = ExceptionMessage };
}
