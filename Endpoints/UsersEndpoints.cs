// using Microsoft.EntityFrameworkCore;
// using TaskApp.Data;
// using TaskApp.Dtos;
// using TaskApp.Mapping;


// namespace TaskApp.Endpoints;

// public static class UsersEndpoints
// { 
//     public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
//     {
//             var getUserEndpointName = "GetUser";
//             var group = app.MapGroup("/users");

//             group.MapGet("/", async (TaskStoreContext db) => 
//             {
//                 var users = await db.Users.ToListAsync();  
//                 Console.WriteLine($"Found {users.Count} users");
//                 return users.Select(user => user.ToUserDetailsDto()).ToList();
//             });
            
//             group.MapGet("/{id}", async (TaskStoreContext dbContext, int id) => 
//             {
//                 var user = await dbContext.Users.FindAsync(id);
//                 if (user == null)
//                 {
//                     return Results.NotFound();
//                 }
//                 return Results.Ok(user.ToUserDetailsDto());
//             });

//         return group;    
//     }
// }