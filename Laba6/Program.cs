using Laba6.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGreetingService, GreetingService>();
var app = builder.Build();
app.Use( async (context, next) =>
{
    if (context.Request.Path == "/greet")
    {
        var greeter = context.RequestServices.GetRequiredService<IGreetingService>();
        string greeting = greeter.GetGreeting();

        context.Response.ContentType = "text/plain; charset=utf-8";
        await context.Response.WriteAsync(greeting);
    }
    else
    {
        await next();
    }
    
});
app.MapGet("/", () => "Hello World!");

app.Run();
