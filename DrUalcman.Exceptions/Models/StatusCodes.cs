namespace DrUalcman.Exceptions.Models;

/// <summary>
/// Status codes RFC 7321
/// https://datatracker.ietf.org/doc/html/rfc7231#section-6
/// </summary>
public class StatusCodes
{
    /// <summary>
    /// Bad Request
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1
    /// </summary>
    public const int Status400BadRequest = 400;
    /// <summary>
    /// Unauthorized [RFC7235]
    /// https://datatracker.ietf.org/doc/html/rfc7235#section-3.1
    /// </summary>
    public const int Status401Unauthorized = 401;
    /// <summary>
    /// Payment Required
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2
    /// </summary>
    public const int Status402PaymentRequired = 402;
    /// <summary>
    /// Forbidden
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3
    /// </summary>
    public const int Status403Forbidden = 403;
    /// <summary>
    /// Not Found
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4
    /// </summary>
    public const int Status404NotFound = 404;
    /// <summary>
    /// Method Not Allowed 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.5
    /// </summary>
    public const int Status405MethodNotAllowed = 405;
    /// <summary>
    /// Not Acceptable
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.6
    /// </summary>
    public const int Status406NotAcceptable = 406;
    /// <summary>
    /// Proxy Authentication Required [RFC7235]
    /// https://datatracker.ietf.org/doc/html/rfc7235#section-3.2
    /// </summary>
    public const int Status407ProxyAuthenticationRequired = 407;
    /// <summary>
    /// Request Timeout
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.7
    /// </summary>
    public const int Status408RequestTimeout = 408;
    /// <summary>
    /// Conflict
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8
    /// </summary>
    public const int Status409Conflict = 409;
    /// <summary>
    /// Gone
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9
    /// </summary>
    public const int Status410Gone = 410;
    /// <summary>
    /// Length Required 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.10
    /// </summary>
    public const int Status411LengthRequired = 411;
    /// <summary>
    /// Precondition Failed [RFC7232]
    /// https://datatracker.ietf.org/doc/html/rfc7232#section-4.2
    /// </summary>
    public const int Status412PreconditionFailed = 412;
    /// <summary>
    /// Payload Too Large
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.11
    /// </summary>
    public const int Status413PayloadTooLarge = 413;
    /// <summary>
    /// URI Too Long  
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.12
    /// </summary>
    public const int Status414UriTooLong = 414;
    /// <summary>
    /// Unsupported Media Type 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.13
    /// </summary>
    public const int Status415UnsupportedMediaType = 415;
    /// <summary>
    /// Range Not Satisfiable [RFC7233]
    /// https://datatracker.ietf.org/doc/html/rfc7233#section-4.4
    /// </summary>
    public const int Status416RequestedRangeNotSatisfiable = 416;
    /// <summary>
    /// Expectation Failed 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.14
    /// </summary>
    public const int Status417ExpectationFailed = 417;
    /// <summary>
    /// Upgrade Required  
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.15
    /// </summary>
    public const int Status426UpgradeRequired = 426;
    /// <summary>
    /// Internal Server Error 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1
    /// </summary>
    public const int Status500InternalServerError = 500;
    /// <summary>
    /// Not Implemented 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.2
    /// </summary>
    public const int Status501NotImplemented = 501;
    /// <summary>
    /// Bad Gateway 
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.3
    /// </summary>
    public const int Status502BadGateway = 502;
    /// <summary>
    /// Service Unavailable
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.4
    /// </summary>
    public const int Status503ServiceUnavailable = 503;
    /// <summary>
    /// Gateway Timeout  
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.5
    /// </summary>
    public const int Status504GatewayTimeout = 504;
    /// <summary>
    /// HTTP Version Not Supported
    /// https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.6
    /// </summary>
    public const int Status505HttpVersionNotsupported = 505;
}
