﻿namespace DrUalcman.Exceptions.Models;

/// <summary>
/// A machine-readable format for specifying errors in HTTP API responses based on
/// https://datatracker.ietf.org/doc/html/rfc7807
/// </summary>
public class ProblemDetails
{
    /// <summary>
    /// A URI reference [RFC3986] that identifies the problem type.
    /// This specification encourages that, when dereferenced, it provide human-readable documentation for the problem type (e.g., using HTML [W3C.REC-html5-20141028]).
    /// When this member is not present, its value is assumed to be "about:blank".
    /// </summary>
    public string Type { get; set; } = default!;

    /// <summary>
    /// A short, human-readable summary of the problem type.It SHOULD NOT change from occurrence to occurrence of the problem, except for purposes of localization 
    /// (e.g.,using proactive content negotiation; see[RFC7231], Section 3.4).
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// The HTTP status code([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.
    /// </summary>
    public StatusCodes? Status { get; set; }

    /// <summary>
    /// A human-readable explanation specific to this occurrence of the problem.
    /// </summary>
    public string Detail { get; set; } = default!;

    /// <summary>
    /// A URI reference that identifies the specific occurrence of the problem.It may or may not yield further information if dereferenced.
    /// </summary>
    public string Instance { get; set; } = default!;

    /// <summary>
    /// Gets the System.Collections.Generic.IDictionary`2 for extension members.
    /// Problem type definitions MAY extend the problem details object with additional
    /// members. Extension members appear in the same namespace as other members of a problem type.
    /// </summary>
    /// <remarks>
    /// The round-tripping behavior for Microsoft.AspNetCore.Mvc.ProblemDetails.Extensions is determined by the implementation of the Input \ Output formatters. In particular,
    /// complex types or collection types may not round-trip to the original type when using the built-in JSON or XML formatters.
    /// </remarks>
    public IDictionary<string, object> Extensions { get; } = new Dictionary<string, object>(StringComparer.Ordinal);

}
