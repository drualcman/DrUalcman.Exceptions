﻿using DrUalcman.Exceptions.Interfaces;
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
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.GetStatusCodeType(StatusCodes.Status400BadRequest),
            Title = "Update exception",
            Detail = exception.Message,
            Instance = exception?.Source ?? "",
            InvalidParams = new Dictionary<string, string>()
        };
        problemDetails.InvalidParams.Add("entries", string.Join(",", exception?.Entries ?? new string[] { } ));
        return ValueTask.FromResult(problemDetails);
    }
}
