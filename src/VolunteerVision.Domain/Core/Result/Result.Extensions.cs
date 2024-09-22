namespace VolunteerVision.Domain.Core.Result;

public static class ResultExtensions
{
    public static async Task<TOut> MatchAsync<TIn, TOut>(
        this Task<Result<TIn>> taskResult,
        Func<TIn, TOut> successCallback,
        Func<Error, TOut> failCallback) where TIn : notnull
    {
        var result = await taskResult;

        return result.IsOk 
        ? successCallback(result.Value)
        : failCallback(result.Error);
    }
}
