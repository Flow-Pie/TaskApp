using Microsoft.EntityFrameworkCore;
using TaskApp.Data;
using TaskApp.Mapping;


namespace TaskApp.Endpoints;

public static class UsersEndpoints
{
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
            var group = app.MapGroup("/users");

            group.MapGet("/", async (TaskStoreContext db) => 
            {
                var users = await db.users.ToListAsync();  
                Console.WriteLine($"Found {users.Count} users");
                return users.Select(user => user.ToUserDetailsDto()).ToList();
            });
        return group;    
    }
}