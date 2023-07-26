namespace DrUalcman.Exceptions;

/// <summary>
/// Generic Exception
/// </summary>
public class UnauthorizeException : Exception
{

    /// <summary>
    /// Constructor
    /// </summary>
    public UnauthorizeException() { }

    /// <summary>
    /// Constructor with message
    /// </summary>
    /// <param name="message"></param>
    public UnauthorizeException(string message) : base(message) { }

    /// <summary>
    /// Constructor with message and exception
    /// </summary>
    /// <param name="message"></param>
    /// <param name="innerException"></param>
    public UnauthorizeException(string message, Exception innerException) : base(message, innerException) { }
}
