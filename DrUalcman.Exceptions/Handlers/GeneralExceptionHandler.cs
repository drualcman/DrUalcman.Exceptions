using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Handlers;

/// <summary>
/// General exception handler
/// </summary>
public class GeneralExceptionHandler : IExceptionHandler<GeneralException>
{
    /// <summary>
    /// General exception handle
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public ValueTask<ProblemDetails> Handle(GeneralException exception)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = StatusCodes.GetStatusCodeType(StatusCodes.Status500InternalServerError),
            Title = exception.Message,
            Detail = exception?.Detail ?? "",
            Instance = exception?.Source ?? ""
        };
        return ValueTask.FromResult(problemDetails);
    }
}
