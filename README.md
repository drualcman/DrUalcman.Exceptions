[![Nuget DrUalcman.Exceptions](https://img.shields.io/nuget/v/DrUalcman.Exceptions?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions](https://www.nuget.org/packages/DrUalcman.Exceptions))
[![Nuget DrUalcman.Exceptions](https://img.shields.io/nuget/dt/DrUalcman.Exceptions?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions](https://www.nuget.org/packages/DrUalcman.Exceptions))
[![Nuget DrUalcman.Exceptions.Extensions](https://img.shields.io/nuget/v/DrUalcman.Exceptions.Extensions?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.Extensions](https://www.nuget.org/packages/DrUalcman.Exceptions.Extensions))
[![Nuget DrUalcman.Exceptions.Extensions](https://img.shields.io/nuget/dt/DrUalcman.Exceptions.Extensions?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.Extensions](https://www.nuget.org/packages/DrUalcman.Exceptions.Extensions))
[![Nuget DrUalcman.Exceptions.MiddleWare](https://img.shields.io/nuget/v/DrUalcman.Exceptions.MiddleWare?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.MiddleWare](https://www.nuget.org/packages/DrUalcman.Exceptions.MiddleWare))
[![Nuget DrUalcman.Exceptions.MiddleWare](https://img.shields.io/nuget/dt/DrUalcman.Exceptions.MiddleWare?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.MiddleWare](https://www.nuget.org/packages/DrUalcman.Exceptions.MiddleWare))
[![Nuget DrUalcman.Exceptions.BlazorWebAssembly.View](https://img.shields.io/nuget/v/DrUalcman.Exceptions.BlazorWebAssembly.View?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.BlazorWebAssembly.View](https://www.nuget.org/packages/DrUalcman.Exceptions.BlazorWebAssembly.View))
[![Nuget DrUalcman.Exceptions.BlazorWebAssembly.View](https://img.shields.io/nuget/dt/DrUalcman.Exceptions.BlazorWebAssembly.View?style=for-the-badge)]([https://www.nuget.org/packages/DrUalcman.Exceptions.BlazorWebAssembly.View](https://www.nuget.org/packages/DrUalcman.Exceptions.BlazorWebAssembly.View))

# DrUalcman.Exceptions
Manage 4 most common exceptions with a default handler using clean architecture. Can be used in any kind of project. 
Always return a ProblemDetails following the standart rfc7807.

# NuGet installation
```PM> Install-Package DrUalcman.Exceptions```

# How to use
```PM> IExceptionHandler<ExceptionType>```
Implement interface in the handlers for the exception. Then inject in the ServiceContainer
```services.AddSingleton<IExceptionPresenter, ExceptionPresenter>();```

# Extensions
```PM> Install-Package DrUalcman.Exceptions.Extensions```
Also can add DrUalcman.Exception.Extension. This DLL only have a dependecy containder extension method to simplify the injection.
```services.AddExceptionsHandlerPresenter()``` or ```services.AddExceptionsHandlerPresenter([Assembly])```
## HttpResponseMessage
We have now a estension method for HttpResponseMessage, return a ```ProblemDetailsException``` to ensure have this exception fromated returned.
```
using HttpResponseMessage response = HttpCliente.GetAsync("endpoint");
response.EnsureSuccessCode();
return response;
```
This return a ```ProblemDetailException``` if the transaction is not Success. If the conent response is formated with a ```ProblemDetail``` parse correctly all the data.

# MiddleWare
```PM> Install-Package DrUalcman.Exceptions.MiddleWare```
Also can add DrUalcman.Exceptions.MiddleWare. This DLL have the methods to add like a MiddleWare.
```
/// when build
builder.Services.AddExceptionsHandlerPresenter(ExceptionHandlersAssemblyHelper.Assembly);
/// before run
app.UseExceptionHandler(builder =>
                builder.UseExceptionHandlerPresenter(
                    app.Environment,
                    app.Services.GetService<IExceptionPresenter>()));
```

# ExceptionView for Blazor
```PM> Install-Package DrUalcman.Exceptions.BlazorWebAssembly.View```
Basic
```
<ExceptionView>
    @Body
</ExceptionView>  
```
Personalize text button
```
<ExceptionView ButtonText="<span class='oi oi-home'></span> OK">
    @Body
</ExceptionView>  
```

