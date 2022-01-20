using DrUalcman.Exceptions;
using DrUalcman.Exceptions.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrUalcman.Exceptions.Extensions
{
    /// <summary>
    /// Extension when is working with HttpClient to get sure a HttpResponse
    /// </summary>
    public static class HttpResponseMessageExcensions
    {
        /// <summary>
        /// If it's not a success code return a ProblemDetailsException
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="ProblemDetailsException"></exception>
        public static HttpResponseMessage EnsureSuccessCode(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode) return response;
            else
            {
                string responseContent = response.Content.ReadAsStringAsync().Result;
                string invalidParams = Regex.Match(responseContent, "{[^{^}]*}").Value;                
                IDictionary<string, string> keyValuePairs = new  Dictionary<string, string>();
                if (!string.IsNullOrEmpty(invalidParams)) keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, string>>(invalidParams);
                ProblemDetails exception = JsonSerializer.Deserialize<ProblemDetails>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = false });
                foreach (KeyValuePair<string, string> item in keyValuePairs)
                {
                    exception.InvalidParams.TryAdd(item.Key, item.Value);
                }

                throw new ProblemDetailsException(exception);
            }
        }


    }
}
