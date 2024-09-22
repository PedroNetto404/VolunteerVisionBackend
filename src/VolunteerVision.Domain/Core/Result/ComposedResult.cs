using System.Text;

namespace VolunteerVision.Domain.Core.Result;

public sealed class ComposedResult 
{
    private readonly List<Result> _results = [];

    public bool IsOk => _results.All(p => p.IsOk);
    public bool IsFail => _results.Any(p => p.IsFail);

    public Error Error =>
        IsFail 
        ? new Error(
            "composed_error", 
            _results.Where(p => p.IsFail)
                    .Aggregate(new StringBuilder(), (strBuilder, current) => 
                    {
                          strBuilder.AppendLine(current.Error.ToString());
                          return strBuilder;
                    })
                    .ToString()
            )
        : throw new InvalidOperationException("No results with error");

    public T FristValueOfType<T>() 
    {
        var resultType = typeof(Result<>).MakeGenericType(typeof(T));
        var element = _results.FirstOrDefault(p => p.GetType().IsAssignableTo(resultType)) 
        ?? throw new InvalidOperationException($"Has not result of type {typeof(T).Name}");

        return (T)element.GetType().GetProperty("Value")!.GetValue(element)!;
    }

    private ComposedResult(params Result[] results) => _results.AddRange(results);

    public static ComposedResult FailEarly(params Func<Result>[] factories)
    {
        List<Result> results = [];
        foreach(var factory in factories)
        {
            var result = factory();
            if(result.IsFail)
            {
                return new ComposedResult(result);
            }

            results.Add(result);
        }

        return new ComposedResult([.. results]);
    }
}
