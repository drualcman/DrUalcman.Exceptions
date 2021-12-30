using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Presenters;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DrUalcman.Exceptions.Extensions;

/// <summary>
/// Helper to add exception handler presenters
/// </summary>
public static class DependencyContainer
{
    /// <summary>
    /// Add exception handler presenters for the current execution assembly
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddExceptionsHandlerPresenter(this IServiceCollection services)
    {
        services.AddSingleton<IExceptionPresenter, ExceptionPresenter>();
        return services;
    }

    /// <summary>
    /// Add exception handler presenters from the assembly
    /// </summary>
    /// <param name="services"></param>
    /// <param name="exceptionHandlersAssembly"></param>
    /// <returns></returns>
    public static IServiceCollection AddExceptionsHandlerPresenter(this IServiceCollection services, Assembly exceptionHandlersAssembly)
    {
        services.AddSingleton<IExceptionPresenter>(provider => new ExceptionPresenter(exceptionHandlersAssembly));
        return services;
    }
}
