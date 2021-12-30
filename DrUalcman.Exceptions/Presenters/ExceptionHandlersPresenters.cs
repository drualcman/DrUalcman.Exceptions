using System.Reflection;

namespace DrUalcman.Exceptions.Presenters;

/// <summary>
/// Helper to get the execution assembly
/// </summary>
public static class ExceptionHandlersPresenters
{
    /// <summary>
    /// Get the executing assembly
    /// </summary>
    public static Assembly Assembly =>
        Assembly.GetExecutingAssembly();
}
