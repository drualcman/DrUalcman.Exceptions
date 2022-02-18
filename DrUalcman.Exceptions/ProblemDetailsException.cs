using DrUalcman.Exceptions.Failures;
using DrUalcman.Exceptions.Interfaces;
using DrUalcman.Exceptions.Models;
using System.Text.Json;

namespace DrUalcman.Exceptions
{
    /// <summary>
    /// Default exception for encapsulate the problem detail to return
    /// </summary>
    public class ProblemDetailsException : Exception
    {
        /// <summary>
        /// A machine-readable format for specifying errors in HTTP API responses based on
        /// https://datatracker.ietf.org/doc/html/rfc7807
        /// </summary>
        public ProblemDetails ProblemDetail { get; set; }

        /// <summary>
        /// constructor basico
        /// </summary>
        public ProblemDetailsException() { }

        /// <summary>
        /// Constructor with message
        /// </summary>
        /// <param name="message"></param>
        public ProblemDetailsException(string message) : base(message) { }

        /// <summary>
        /// Constructor with message and exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ProblemDetailsException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>
        /// contructor que recibe la respuesta con los errores
        /// </summary>
        /// <param name="problemDetails"></param>
        public ProblemDetailsException(ProblemDetails problemDetails) => 
            ProblemDetail = problemDetails;

        /// <summary>
        /// contructor que recibe la respuesta con los errores
        /// </summary>
        /// <param name="message"></param>
        /// <param name="problemDetails"></param>
        public ProblemDetailsException(string message, ProblemDetails problemDetails) : base(message) =>
            ProblemDetail = problemDetails;

        /// <summary>
        /// contructor que recive un jsonElement para poder serializarlo dentro del problem details
        /// </summary>
        /// <param name="jsonResponse"></param>
        public ProblemDetailsException(JsonElement jsonResponse) =>
            ProblemDetail = JsonSerializer.Deserialize<ProblemDetails>(jsonResponse.GetRawText(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}