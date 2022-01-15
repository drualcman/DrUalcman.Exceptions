﻿using DrUalcman.Exceptions.Interfaces;
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
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = "Exception when validate the entrie/s.",
            Detail = "One or more exceptions occurs."
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