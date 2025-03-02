using Microsoft.EntityFrameworkCore;
using TaskApp.Data;
using TaskApp.Dtos;
using TaskApp.Mapping;


namespace TaskApp.Endpoints;

public static class UsersEndpoints
{ 
    public static RouteGroupBuilder MapUsersEndpoints(this WebApplication app)
    {
            var getUserEndpointName = "GetUser";
            var group = app.MapGroup("/users").WithParameterValidation();
          
           
            group.MapGet("/", async (TaskStoreContext db) =>
            {
                try
                {
                    return Results.Ok(await db.Users
                        .Select(user => user.ToUserDetailsDto())
                        .AsNoTracking()
                        .ToListAsync());
                }
                catch (Exception ex)
                {
                    return Results.Problem($"An error {ex.Message} occurred while fetching users.", statusCode: 500);
                }
            });

            
            group.MapGet("/{id}", async (TaskStoreContext db, int id) => 
            {
                try{
                    User? user = await db.Users.FindAsync(id);
                    return user is null ? Results.NotFound("Not found") : Results.Ok(user.ToUserDetailsDto());
                }catch(Exception ex){
                    return Results.Problem($"An error {ex.Message} occurred while fetching user.", statusCode: 500);
                }
            }).WithName(getUserEndpointName);

            group.MapPost("/", async (CreateUserDto newUser, TaskStoreContext db)=>
            {
                try{

                    User user = newUser.ToUserEntity();
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                    return Results.CreatedAtRoute(getUserEndpointName, new {id = user.UserId}, user.ToUserDetailsDto());
                }catch(Exception ex){
                    return Results.Problem($"An error {ex.Message} occurred while creating user.", statusCode: 500);
                }
            } 
            );

            group.MapPut("/{id}", async (int id, UpdateUserDto updatedUser, TaskStoreContext db) =>{
                try{
                    var user = await db.Users.FindAsync(id);
                    if(user is null) return Results.NotFound("User id not found in the db.");

                    db.Entry(user).CurrentValues.SetValues(updatedUser.ToUserEntity(id));
                    await db.SaveChangesAsync();

                    return Results.Ok($"User id {id} updated successfully"); 
                }catch(Exception ex){
                    return Results.Problem($"An error {ex.Message} occurred while updating user.", statusCode: 500);
                }
            });

            group.MapDelete("/{id}", async (int id, TaskStoreContext db) => {
                try{
                    var user = await db.Users.FindAsync(id);
                    if(user is null) return Results.NotFound("User id not found in the db.");
                    
                    await db.Users.Where(user => user.UserId == id).ExecuteDeleteAsync();

                    return Results.Ok($"User id {id} deleted successfully");
                    
                }catch(Exception ex){
                    return Results.Problem($"An error {ex.Message} occurred while deleting user.", statusCode: 500);
                }
                
            });
            

        return group;    
    }
}