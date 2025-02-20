using TaskApp.Endpoints;

var builder  =  WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapTasksEndpoints();

app.Run();