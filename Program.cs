using TaskApp.Endpoints;
using TaskApp.Data;

var builder  =  WebApplication.CreateBuilder(args);//builder container

var connString = builder.Configuration.GetConnectionString("TaskStore") ?? throw new InvalidOperationException("Connection string 'TaskStore' not found.");

//Addsqlite -add new services to the container (Scoped lifetime)
//asp can now consume sqlite api
builder.Services.AddSqlite<TaskStoreContext>(connString);



var app = builder.Build();

app.MapTasksEndpoints();
app.MapUsersEndpoints();

app.MapGet("/", () => "Hello World!");

await app.MigrateDbAsync();

app.Run();