using Microsoft.EntityFrameworkCore;

namespace TaskApp.Data;

public static class DataExtensions
{
    public static async Task  MigrateDbAsync (this WebApplication app)
    {
        using var scope = app.Services.CreateScope();//instance of scope lifetime
        var dbContext = scope.ServiceProvider.GetRequiredService<TaskStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}