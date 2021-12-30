using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Interfaces
{
    /// <summary>
    /// Exception handler abstraction
    /// </summary>
    public interface IExceptionHandler<ExceptionType> where ExceptionType : Exception
    {
        /// <summary>
        /// Exception handle
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        ValueTask<ProblemDetails> Handle(ExceptionType exception);
    }
}
