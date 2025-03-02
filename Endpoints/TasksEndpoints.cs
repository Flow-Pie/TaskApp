namespace TaskApp.Endpoints;

using TaskApp.Dtos;
using TaskApp.Data;
using TaskApp.Entities;
using TaskApp.Mapping;
using Microsoft.EntityFrameworkCore;

public static class TasksEndpoints{

    //this makes the endpoint available to the application ie extendable
    public static  RouteGroupBuilder MapTasksEndpoints (this WebApplication app)
    {     
        const string GetTaskEndpointName = "GetTask";
        var group = app.MapGroup("/tasks").WithParameterValidation();//to recognise Data Validations from Create Dto

        group.MapGet("/", async (TaskStoreContext db) => 
        {
                    try{
                        return Results.Ok(await  db.Tasks
                            .Select(task => task.ToTaskDetailsDto())
                            .AsNoTracking()
                            .ToListAsync());
                    }catch(Exception ex){
                        return Results.Problem($"An error {ex.Message} occurred while fetching tasks.", statusCode: 500);
                    }
        });
         

        group.MapGet("/{id}", async (int id, TaskStoreContext db)=> 
        {
            try{
                Tasks? task  = await db.Tasks.FindAsync(id);
                return  task is null ? Results.NotFound($"Task id {id} not Found") : Results.Ok(task.ToTaskDetailsDto());
            }catch(Exception ex){
                return Results.Problem($"An error {ex.Message} occurred while fetching task.", statusCode: 500);
            }
            
        }).WithName(GetTaskEndpointName);


        //POST request

        group.MapPost("/",async (CreateTaskDto newTask, TaskStoreContext db) =>
        {
            try{
                if(string.IsNullOrEmpty(newTask.TaskTitle)) return Results.BadRequest("Task title  is required");                                  

                db.Tasks.Add(newTask.ToEntity());   
                await db.SaveChangesAsync();
                //returning Dto instead of internal entity to user           
                return Results.CreatedAtRoute(GetTaskEndpointName, new {id=newTask.ToEntity().TaskId },new {Task = "Task Created Successfully " + newTask.ToEntity().ToTaskDetailsDto()});
            }catch(Exception ex){
                return Results.Problem($"An error {ex.Message} occurred while creating task.", statusCode: 500);
            }
        });


        //PUT request 
        //!!not fully thread safe for now
        group.MapPut("/{id}", async (int id , UpdateTaskDto updatedTask, TaskStoreContext db) =>
        {
            try{
                var existingTask = await db.Tasks.FindAsync(id);
                if(existingTask is null) return Results.NotFound("Task not found");            
                
                db.Entry(existingTask)
                .CurrentValues.SetValues(updatedTask.ToEntity(id));

                await db.SaveChangesAsync();

                return Results.Ok("Task Updated Successfully");
            }catch(Exception ex){
                return Results.Problem($"An error {ex.Message} occurred while updating task.", statusCode: 500);
            }

        });  

        //DELETE request    
        group.MapDelete("/{id}",async (int id, TaskStoreContext db) =>
        {
            try{
                await db.Tasks.Where(task => task.TaskId == id).ExecuteDeleteAsync();

                return Results.Ok($"task id {id} Deleted Successfully");
            }catch(Exception ex){
                return Results.Problem($"An error {ex.Message} occurred while deleting task.", statusCode: 500);
            }
        });

        return group;

    }

}
