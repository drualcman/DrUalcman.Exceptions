# DrUalcman.Exceptions
Manage 3 most common exceptions with a default handler using clean architecture. Can be used in any kind of project. 
Always return a ProblemDetails following the standart rfc7807.

# NuGet installation
```PM> Install-Package DrUalcman-Excep[tions]```

# How to use
Implement interface 
```IExceptionHandler<ExceptionType>```
in the handlers for the exception. Then inject in the ServiceContainer
```services.AddSingleton<IExceptionPresenter, ExceptionPresenter>();```

# Extensions
Also can add DrUalcman.Exception.Extension. This DLL only have a dependecy containder extension method to simplify the injection.
```services.AddExceptionsHandlerPresenter()``` or ```services.AddExceptionsHandlerPresenter([Assembly])```

# MiddleWare
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

