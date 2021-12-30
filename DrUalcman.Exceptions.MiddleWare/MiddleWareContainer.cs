using DrUalcman.Exceptions.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace DrUalcman.Exceptions.MiddleWare;

/// <summary>
/// inject middleware
/// </summary>
public static class MiddleWareContainer
{
    /// <summary>
    /// Inject exception handle presneters
    /// </summary>
    /// <param name="app"></param>
    /// <param name="enviroment"></param>
    /// <param name="presenter"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseExceptionHandlerPresenter(this IApplicationBuilder app, IHostEnvironment enviroment, IExceptionPresenter presenter)
    {
        app.Use((context, next) => MiddleWare.WriteResponse(context, enviroment.IsDevelopment(), presenter));
        return app;
    }
}
