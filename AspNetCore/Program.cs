var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => $"Days to next New Year: {(new DateTime(DateTime.Now.Year + 1, 1, 1) - DateTime.Now).Days.ToString()}");
app.MapGet("/hello", (string name) => $"Hello, {name} ");

app.Run();