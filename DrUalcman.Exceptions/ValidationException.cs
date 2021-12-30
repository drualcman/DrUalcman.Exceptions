using DrUalcman.Exceptions.Failures;

namespace DrUalcman.Exceptions;

/// <summary>
/// Validation exception
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Failure list
    /// </summary>
    public IReadOnlyList<IFailure> Failures { get; } = null!;

    /// <summary>
    /// Consuctor 
    /// </summary>
    public ValidationException() { }

    /// <summary>
    /// Constructor with message
    /// </summary>
    /// <param name="message"></param>
    public ValidationException(string message) : base(message) { }

    /// <summary>
    /// Constructor with message and exception
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public ValidationException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Constructor with failure list
    /// </summary>
    /// <param name="failures"></param>
    public ValidationException(IReadOnlyList<IFailure> failures) : base($"Found {failures.Count}.") =>
        Failures = failures;
}
