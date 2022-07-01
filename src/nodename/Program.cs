var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
    $"Hello World!\n" + 
    $"ASPNETCORE_ENVIRONMENT={Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}\n" +
    $"NODE_NAME={Environment.GetEnvironmentVariable("NODE_NAME")}\n"
    );

app.Run();
