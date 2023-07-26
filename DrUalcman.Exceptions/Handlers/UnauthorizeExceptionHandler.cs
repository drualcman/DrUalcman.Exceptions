using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Handlers;

/// <summary>
/// Validation exception handler
/// </summary>
public class UnauthorizeExceptionHandler : IExceptionHandler<UnauthorizeException>
{
    /// <summary>
    /// Validation excetion handle
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public ValueTask<ProblemDetails> Handle(UnauthorizeException exception)
    {
        var ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status401Unauthorized,
            Type = StatusCodes.GetStatusCodeType(StatusCodes.Status401Unauthorized),
            Title = "Unauthorized.",
            Detail = string.IsNullOrEmpty(exception.Message) ? "You don't have access to the resource are you looking for." : exception.Message,
            Instance = exception?.Source ?? "",
            InvalidParams = new Dictionary<string, string>()
        };
        return ValueTask.FromResult(ProblemDetails);
    }
}
