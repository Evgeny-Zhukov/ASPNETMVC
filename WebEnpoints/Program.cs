using WebEnpoints.Models;
using WebEnpoints.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ControllerRequestCounterFilter>();
});

var app = builder.Build();
app.MapControllers();
app.MapDefaultControllerRoute();


/*app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/api/courses", async context =>
        await context.Response.WriteAsJsonAsync(Course.All));
    endpoints.MapGet("/api/course/{id:int}", async (context) =>
        await context.Response.WriteAsJsonAsync(Course.All));
});*/

app.MapGet("/api/course", async context =>
        await context.Response.WriteAsJsonAsync(Course.All));

app.MapGet("/api/course/{id:int}", async (HttpContext context, int id) =>
        {
            Course c = Course.All.Where(c => c.Id == id).SingleOrDefault();
            if (c != null)
                await context.Response.WriteAsJsonAsync(c);
            else
                context.Response.StatusCode = StatusCodes.Status404NotFound;
        });

app.MapGet("/api/course/search/{search}", async (HttpContext context, string search) =>
{
    var result = Course.All
        .Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
        .ToList();

    await context.Response.WriteAsJsonAsync(result);
});

app.MapDelete("/api/course/{id:int}", async (HttpContext context, int id) =>
{
    Course c = Course.All.Where(c => c.Id == id).SingleOrDefault();
    if (c != null)
        Course.All.Remove(c);
    else
        context.Response.StatusCode = StatusCodes.Status404NotFound;

});

app.MapPost("/api/course", async(HttpContext context, Course c) => {
    if (c.Id == 0) 
        c.Id = Course.All.Select(c => c.Id).Max() + 1;

    Course.All.Add(c);
    await context.Response.WriteAsJsonAsync(c);
});

app.Run();
