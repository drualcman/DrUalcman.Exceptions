namespace DrUalcman.Exceptions;

/// <summary>
/// Update exception
/// </summary>
public class UpdateException : Exception
{
    /// <summary>
    /// List with the entries names
    /// </summary>
    public IReadOnlyList<string> Entries { get; set; } = null!;

    /// <summary>
    /// Consuctor 
    /// </summary>
    public UpdateException() { }

    /// <summary>
    /// Constructor with message
    /// </summary>
    /// <param name="message"></param>
    public UpdateException(string message) : base(message) { }

    /// <summary>
    /// Constructor with message and exception
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public UpdateException(string message, Exception innerException) : base(message, innerException) { }

    /// <summary>
    /// Constructor with entries
    /// </summary>
    /// <param name="entries"></param>
    public UpdateException(IReadOnlyList<string> entries) : base($"Found {entries.Count}.") =>
        Entries = entries;

    /// <summary>
    /// Constructor with message and entries
    /// </summary>
    /// <param name="message"></param>
    /// <param name="entries"></param>
    public UpdateException(string message, IReadOnlyList<string> entries) : base(message) =>
        Entries = entries;
}
