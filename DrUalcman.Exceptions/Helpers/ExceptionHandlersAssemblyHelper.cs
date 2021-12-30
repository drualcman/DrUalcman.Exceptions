using System.Reflection;

namespace DrUalcman.Exceptions.Helpers;

/// <summary>
/// Helper to get the execution assembly
/// </summary>
public static class ExceptionHandlersAssemblyHelper
{
    /// <summary>
    /// Get the executing assembly
    /// </summary>
    public static Assembly Assembly =>
        Assembly.GetExecutingAssembly();
}
