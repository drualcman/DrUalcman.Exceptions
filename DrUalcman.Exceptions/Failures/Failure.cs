namespace DrUalcman.Exceptions.Failures;

/// <summary>
/// Failure definition
/// </summary>
public class Failure : IFailure
{
    /// <summary>
    /// Property name
    /// </summary>
    public string PropertyName { get; }
    /// <summary>
    /// Error message
    /// </summary>
    public string ErrorMessage { get; }
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="errorMessage"></param>
    public Failure(string propertyName, string errorMessage)
    {
        PropertyName = propertyName;
        ErrorMessage = errorMessage;
    }
}
