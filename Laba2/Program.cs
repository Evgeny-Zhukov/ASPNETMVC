var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await next();
});

app.Use(async (context, next) =>
{
    var path = context.Request.Path;

    if (path == "/")
    {
        await context.Response.WriteAsync("<h1>Добро пожаловать!</1>");
    }
    else if (path == "/date")
    {
        string date = DateTime.Now.ToString("dd.MM.yyyy");
        await context.Response.WriteAsync($"<h2>Сегодня: {date}</h2>");
    }
    else if (path == "/time")
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
        await context.Response.WriteAsync($"<h2>Текуще время: {time}</h2>");
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("<h3>Ошибка 404. Ресурс не найден.</h3>");
    }
    await next();
});

app.Run();
