namespace VolunteerVision.Domain.Core.Error;

public record ErrorOr<T> where T : notnull
{
    private T? _value;
    private Error? _error;

    public bool IsOk => _value is not null && _error is null;

    public bool IsFail => !IsOk;

    public T Value => IsOk ? _value! : throw new InvalidOperationException("Error occurred. Value is not available.");

    private ErrorOr() { }

    public static ErrorOr<T> Ok(T value) => new() { _value = value };

    public static ErrorOr<T> Fail(Error error) => new() { _error = error };

    public static implicit operator T(ErrorOr<T> errorOr) => errorOr.Value;

    public static implicit operator Error(ErrorOr<T> errorOr) => errorOr._error!;

    public static implicit operator ErrorOr<T>(T value) => Ok(value);

    public static implicit operator ErrorOr<T>(Error error) => Fail(error);
}

public sealed record Error(string Code, string Message);
