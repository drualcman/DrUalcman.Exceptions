using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Handlers;

/// <summary>
/// Update exception handler
/// </summary>
public class UpdateExceptionHandler : IExceptionHandler<UpdateException>
{
    /// <summary>
    /// Update exception handle
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public ValueTask<ProblemDetails> Handle(UpdateException exception)
    {
        Dictionary<string, string> exceptions = new Dictionary<string, string>
            {
                { "entities", string.Join(",", exception.Entries) }
            };
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://datatracker.irtf.org/doc/html/rtfc7231@section-6.5.1",
            Title = "Update exception",
            Detail = exception.Message
        };
        problemDetails.Extensions.Add("invalid-params", exceptions);
        return ValueTask.FromResult(problemDetails);
    }
}
