using DrUalcman.Exceptions.Helpers;
using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;
using System.Reflection;

namespace DrUalcman.Exceptions.Presenters;
#nullable disable
/// <summary>
/// Default presenter implementation
/// </summary>
public class ExceptionPresenter : IExceptionPresenter
{
    /// <summary>
    /// Dictionary to store all the exception handlers
    /// </summary>
    static readonly Dictionary<Type, Type> ExceptionHandlers = new Dictionary<Type, Type>();

    /// <summary>
    /// Constructor get fro default the execution assembly for search all the exceptions
    /// </summary>
    public ExceptionPresenter() : this(ExceptionHandlersAssemblyHelper.Assembly) { }

    /// <summary>
    /// Constructor will search all the exception handlers
    /// </summary>
    /// <param name="exceptionHandlerAssembly"></param>
    public ExceptionPresenter(Assembly exceptionHandlerAssembly)
    {
        Type[] types = exceptionHandlerAssembly.GetTypes();
        foreach (Type t in types)
        {
            var handlers = t.GetInterfaces()
                .Where(i => i.IsGenericType
                         && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
            foreach (Type i in handlers)
            {
                var exceptionType = i.GetGenericArguments()[0];
                ExceptionHandlers.TryAdd(exceptionType, t);
            }
        }
    }

    /// <summary>
    /// Exception content
    /// </summary>
    public ProblemDetails Content { get; private set; }

    /// <summary>
    /// Handle the exception to return a ProblemDetails
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="includeDetails"></param>
    /// <returns></returns>
    public async ValueTask Handle(Exception ex, bool includeDetails)
    {
        ProblemDetails problem;
        if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type handlerType))
        {
            var handler = Activator.CreateInstance(handlerType);
            try
            {
                problem = await (ValueTask<ProblemDetails>)handlerType.GetMethod("Handle").Invoke(handler, new object[] { ex });
            }
            catch
            {
                problem = new ProblemDetails
                {
                    Status = StatusCodes.Status412PreconditionFailed,
                    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section6.6.1",
                    Title = includeDetails ? ex.Message : "An error occurred while processing the response",
                    Detail = includeDetails ? ex.ToString() : "Consult the administrator",
                    Instance = ex.Source ?? ""
                };
            }
        }
        else
        {
            problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section6.6.1",
                Title = includeDetails ? ex.Message : "An error occurred while processing the response",
                Detail = includeDetails ? ex.ToString() : "Consult the administrator",
                Instance = ex.Source ?? ""
            };
        }
        Content = problem;
    }
}
