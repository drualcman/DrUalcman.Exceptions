using DrUalcman.Exceptions.Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DrUalcman.Exceptions.MiddleWare;

/// <summary>
/// Transation Middleware
/// </summary>
class MiddleWare
{
    /// <summary>
    /// Capture the exception and present like problem details
    /// https://datatracker.ietf.org/doc/html/rfc7807
    /// </summary>
    /// <param name="context"></param>
    /// <param name="includeDetails"></param>
    /// <param name="presenter"></param>
    /// <returns></returns>
    public static async Task WriteResponse(HttpContext context, bool includeDetails, IExceptionPresenter presenter)
    {
        IExceptionHandlerFeature exceptionDetail = context.Features.Get<IExceptionHandlerFeature>();
        Exception exception = exceptionDetail.Error;

        if (exception != null)
        {
            await presenter.Handle(exception, includeDetails);
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = presenter.Content.Status;
            var stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(stream, presenter.Content);
        }
    }
}
