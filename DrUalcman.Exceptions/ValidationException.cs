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

    /// <summary>
    /// Constructor to send only one error
    /// </summary>
    /// <param name="message"></param>
    /// <param name="propertyName"></param>
    /// <param name="error"></param>
    public ValidationException(string message, string propertyName, string error) : base(message) =>
        Failures = new List<Failure>
        {
            new Failure(propertyName, error)
        };

    /// <summary>
    /// Constructor can receive collection of KeyValuePair
    /// </summary>
    /// <param name="message"></param>
    /// <param name="failues">list KeyValuePair key = property name, value = error message</param>
    public ValidationException(string message, IEnumerable<KeyValuePair<string, string>> failues) : base(message)
    {
        Failures = new List<Failure>();
        foreach (var failure in failues)
        {
            if (Failures.FirstOrDefault(f=> f.PropertyName == failure.Key && f.ErrorMessage == failure.Value) is null)
            {
                Failures.Append(new Failure(failure.Key, failure.Value));
            }
        }
    }
}
