namespace TaskApp.Endpoints;

using TaskApp.Dtos;
using TaskApp.Data;
using TaskApp.Entities;
using TaskApp.Mapping;

public static class TasksEndpoints{


    const string GetTaskEndpointName = "GetTask";

    internal static  readonly List <TaskDetailsDto> tasks = [     
        new (1,3,"Task 1","Task 1 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (2,3,"Task 2","Task 2 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (3,3,"Task 3","Task 3 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (4,3,"Task 4","Task 4 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (5,3,"Task 5","Task 5 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (6,3,"Task 6","Task 6 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (7,3,"Task 7","Task 7 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (8,3,"Task 8","Task 8 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (9,3,"Task 9","Task 9 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1))),
        new (10,3,"Task 10","Task 10 Description",new DateTime(2020-2-1),true,"High",DateOnly.FromDateTime(new DateTime(2020-2-1)))
    
    ];

    //this makes the endpoint available to the application ie extendable
    public static  RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
    {     
        var group = app.MapGroup("/tasks");

        group.MapGet("/", () => tasks);

        group.MapGet("/{id}", (int id, TaskStoreContext db)=> 
        {
            Tasks? task  = db.tasks.Find(id);
            return  task is null ? Results.NotFound() : Results.Ok(task.toTaskDetailsDto());
            
        }).WithName(GetTaskEndpointName);


        //POST request

        group.MapPost("/", (CreateTaskDto newTask, TaskStoreContext db) =>
        {
            if(string.IsNullOrEmpty(newTask.TaskTitle)){
                return Results.BadRequest("Task title  is required");
            }

            Tasks task = newTask.ToEntity();            

            db.tasks.Add(task);   
            db.SaveChanges();

            //never make a mistake of returning internal entity to user instead return DTO

           TaskDetailsDto taskDetailsDto =  task.toTaskDetailsDto();
            tasks.Add(taskDetailsDto);//!! only for testing purposes ,,, atleast for now           


        return Results.CreatedAtRoute(GetTaskEndpointName, new {id=task.TaskId },new {Task = "Task Created Successfully " + taskDetailsDto});
        }).WithParameterValidation();//to recognise Data Validations


        //PUT request 
        //!! not thread safe for now
        group.MapPut("/{id}", (int id , UpdateTaskDto updatedTask, TaskStoreContext db) =>
        {
            var existingTask = db.tasks.Find(id);

            if(existingTask is null) return Results.NotFound("Task not found");
            // tasks[index]= new TaskDetailsDto(
            //     id,
            //     updatedTask.userId,
            //     updatedTask.TaskTitle,
            //     updatedTask.TaskDescription,
            //     updatedTask.TaskDate,
            //     updatedTask.Status,
            //     updatedTask.TaskPriority,
            //     updatedTask.dateCreated
            // );
            

            return Results.Ok("Task Updated Successfully");

        }).WithParameterValidation();  

        //DELETE request    
        group.MapDelete("/{id}", (int id)=>
        {
            tasks.RemoveAll(task => task.taskId == id);

            return Results.Ok($"task id {id} Deleted Successfully");
        });

        return group;

    }

}
