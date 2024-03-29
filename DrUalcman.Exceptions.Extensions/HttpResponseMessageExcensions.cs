﻿using DrUalcman.Exceptions.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

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
            if(response.IsSuccessStatusCode) return response;
            else
            {
                ProblemDetails exception;
                switch(response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                    case System.Net.HttpStatusCode.Forbidden:
                    case System.Net.HttpStatusCode.NotFound:
                        exception = new ProblemDetails("", response?.ReasonPhrase!, (int)response?.StatusCode!, "", "", null!);
                        string responseContent = response.Content.ReadAsStringAsync().Result;
                        if(!string.IsNullOrEmpty(responseContent))
                        {
                            string invalidParams = Regex.Match(responseContent, "{[^{^}]*}").Value;
                            if(!string.IsNullOrEmpty(invalidParams))
                            {
                                IDictionary<string, string[]> keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, string[]>>(invalidParams)!;
                                if(keyValuePairs != null)
                                {
                                    exception.InvalidParams = new Dictionary<string, string>();
                                    foreach(KeyValuePair<string, string[]> item in keyValuePairs)
                                    {
                                        exception.InvalidParams.TryAdd(item.Key, string.Join('.', item.Value));
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        try
                        {
                            exception = response.Content.ReadFromJsonAsync<ProblemDetails>().Result;
                        }
                        catch(Exception ex)
                        {
                            exception = new ProblemDetails(ex?.HelpLink!, response?.ReasonPhrase!, (int)response?.StatusCode!, ex?.Message!, "", new Dictionary<string, string>());
                        }
                        break;
                }
                throw new ProblemDetailsException(exception);
            }
        }

        /// <summary>
        /// If it's not a success code return a ProblemDetailsException
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        /// <exception cref="ProblemDetailsException"></exception>
        public async static Task<HttpResponseMessage> EnsureSuccessCodeAsync(this HttpResponseMessage response)
        {
            if(response.IsSuccessStatusCode) return response;
            else
            {
                ProblemDetails exception;
                switch(response.StatusCode)
                {
                    case System.Net.HttpStatusCode.Unauthorized:
                    case System.Net.HttpStatusCode.Forbidden:
                    case System.Net.HttpStatusCode.NotFound:
                        exception = new ProblemDetails("", response?.ReasonPhrase!, (int)response?.StatusCode!, "", "", null!);
                        break;
                    default:
                        try
                        {
                            exception = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                        }
                        catch(Exception ex)
                        {
                            exception = new ProblemDetails(ex?.HelpLink!, response?.ReasonPhrase!, (int)response?.StatusCode!, ex?.Message!, "", null!);
                        }
                        break;
                }
                if(exception.InvalidParams is null)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    string invalidParams = Regex.Match(responseContent, "{[^{^}]*}").Value;
                    if(!string.IsNullOrEmpty(invalidParams))
                    {
                        IDictionary<string, string[]> keyValuePairs = JsonSerializer.Deserialize<IDictionary<string, string[]>>(invalidParams)!;
                        if(keyValuePairs != null)
                        {
                            exception.InvalidParams = new Dictionary<string, string>();
                            foreach(KeyValuePair<string, string[]> item in keyValuePairs)
                            {
                                exception.InvalidParams.TryAdd(item.Key, string.Join('.', item.Value));
                            }
                        }
                    }
                }
                throw new ProblemDetailsException(exception);
            }
        }
    }
}
