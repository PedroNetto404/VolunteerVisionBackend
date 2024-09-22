namespace VolunteerVision.Domain.Core.Result;

public class Result
{
    private readonly Error? _error;

    public bool IsFail => !IsOk;
    public bool IsOk => _error is null;
    public Error Error =>
        IsFail 
        ? _error!
        : throw new InvalidOperationException("Cannot get error for non fail result");

    protected Result(Error error) => _error = error;
    protected Result() => _error = default!;
    
    public static Result Ok() => new();
    public static Result<T> Ok<T>(T value) where T : notnull => Result<T>.Ok(value);
    public static Result Fail(Error error) => new(error); 
    public static Result<T> Fail<T>(Error error) where T : notnull => Result<T>.Fail(error);

    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Error(Result result) => result.Error;
}
