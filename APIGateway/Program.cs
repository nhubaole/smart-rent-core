using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();
app.UseOcelot().Wait();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
