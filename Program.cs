using TaskApp.Endpoints;
using TaskApp.Data;

var builder  =  WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("TaskStore") ?? throw new InvalidOperationException("Connection string 'TaskStore' not found.");
builder.Services.AddSqlite<TaskStoreContext>(connString);

var app = builder.Build();

app.MapTasksEndpoints();

app.Run();