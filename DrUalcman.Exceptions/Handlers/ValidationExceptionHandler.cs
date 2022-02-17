using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Handlers;

/// <summary>
/// Validation exception handler
/// </summary>
public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    /// <summary>
    /// Validation excetion handle
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public ValueTask<ProblemDetails> Handle(ValidationException exception)
    {
        var ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.GetStatusCodeType(StatusCodes.Status400BadRequest),
            Title = "Exception when validate the entrie/s.",
            Detail = "One or more exceptions occurs.",
            Instance = exception?.Source ?? ""
        };

        foreach (var failure in exception.Failures)
        {
            if (ProblemDetails.InvalidParams.ContainsKey(failure.PropertyName))
            {
                ProblemDetails.InvalidParams[failure.PropertyName] += " " + failure.ErrorMessage;
            }
            else
            {
                ProblemDetails.InvalidParams.Add(failure.PropertyName, failure.ErrorMessage);
            }
        }
        return ValueTask.FromResult(ProblemDetails);
    }
}
