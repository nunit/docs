// A minimal web application used as the system under test by the
// WebApplicationFactory examples in Snippets.NUnit.AspNetCore.

#region WebAppProgram
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (ILogger<Program> logger) =>
{
    Console.WriteLine("Console.WriteLine from inside the request handler");
    logger.LogInformation("ILogger output from inside the request handler");
    return "Hello from the application";
});

app.Run();

// Makes the implicit Program class visible to WebApplicationFactory<Program> in the test project.
public partial class Program;
#endregion
