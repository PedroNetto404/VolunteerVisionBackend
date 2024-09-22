namespace VolunteerVision.Domain.Core.Result;

public class Result<T> : Result where T : notnull 
{
    private readonly T? _value;

    public T Value =>
        IsOk
        ? _value!
        : throw new InvalidOperationException("Cannot get a value for non ok result");

    private Result(T value) => _value = value;
    private Result(Error error) : base(error) { }

    public static Result<T> Ok(T value) => new(value);
    public static new Result<T> Fail(Error error) => new(error);

    public static implicit operator Result<T>(T value) => Ok(value);
    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(Error error) => Fail(error);
    public static implicit operator Error(Result<T> result) => result.Error;
}
