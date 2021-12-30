using DrUalcman.Exceptions.Models;

namespace DrUalcman.Exceptions.Interfaces;

/// <summary>
/// Abstraer la presentacion del error
/// </summary>
public interface IExceptionPresenter
{
    /// <summary>
    /// El contenido de la excepcion
    /// </summary>
    ProblemDetails Content { get; }

    /// <summary>
    /// Manejar la excepcion a presentar
    /// </summary>
    /// <param name="ex"></param>
    /// <param name="includeDetails"></param>
    /// <returns></returns>
    ValueTask Handle(Exception ex, bool includeDetails);
}
