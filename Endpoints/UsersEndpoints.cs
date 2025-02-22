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
            await   db.users
                    .Select(user => user.ToUserDetailsDto())
                    .AsNoTracking()
                    .ToListAsync()                
                    );

            return group;            
    }
}