namespace TaskApp.Endpoints;

using TaskApp.Dtos;
using TaskApp.Data;
using TaskApp.Entities;
using TaskApp.Mapping;
using Microsoft.EntityFrameworkCore;

public static class TasksEndpoints{


    const string GetTaskEndpointName = "GetTask";

    //internal static  readonly List <TaskDetailsDto> tasks = [];//!No need for in memory task.This line will be removed

    //this makes the endpoint available to the application ie extendable
    public static  RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
    {     
        var group = app.MapGroup("/tasks");

        group.MapGet("/", async (TaskStoreContext db) => 
                    await   db.tasks
                            .Select(task => task.ToTaskDetailsDto())
                            .AsNoTracking()
                            .ToListAsync()
                            );

        group.MapGet("/{id}", async (int id, TaskStoreContext db)=> 
        {
            Tasks? task  = await db.tasks.FindAsync(id);
            return  task is null ? Results.NotFound() : Results.Ok(task.ToTaskDetailsDto());
            
        }).WithName(GetTaskEndpointName);


        //POST request

        group.MapPost("/",async (CreateTaskDto newTask, TaskStoreContext db) =>
        {
            if(string.IsNullOrEmpty(newTask.TaskTitle)){
                return Results.BadRequest("Task title  is required");
            }

            Tasks task = newTask.ToEntity();            

            db.tasks.Add(task);   
            await db.SaveChangesAsync();

            //never make a mistake of returning internal entity to user instead return DTO

           TaskDetailsDto taskDetailsDto =  task.ToTaskDetailsDto();
           // tasks.Add(taskDetailsDto);//!! only for testing purposes ,,, atleast for now           


        return Results.CreatedAtRoute(GetTaskEndpointName, new {id=task.TaskId },new {Task = "Task Created Successfully " + taskDetailsDto});
        }).WithParameterValidation();//to recognise Data Validations


        //PUT request 
        //!! not thread safe for now
        group.MapPut("/{id}", async (int id , UpdateTaskDto updatedTask, TaskStoreContext db) =>
        {
            var existingTask = await db.tasks.FindAsync(id);

            if(existingTask is null) return Results.NotFound("Task not found");            
            
            db.Entry(existingTask)
            .CurrentValues.SetValues(updatedTask.ToEntity(id));

            await db.SaveChangesAsync();

            return Results.Ok("Task Updated Successfully");

        }).WithParameterValidation();  

        //DELETE request    
        group.MapDelete("/{id}",async (int id, TaskStoreContext db) =>
        {
            await db.tasks.Where(task => task.TaskId == id)
            .ExecuteDeleteAsync();


            return Results.Ok($"task id {id} Deleted Successfully");
        });

        return group;

    }

}
