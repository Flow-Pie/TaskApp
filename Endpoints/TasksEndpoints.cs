namespace TaskApp.Endpoints;
using TaskApp.Dtos;


public static class TasksEndpoints{


    const string GetTaskEndpointName = "GetTask";

    private static  readonly List <TaskDto> tasks = [     
        new (1,3,"Task 1","Task 1 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (2,3,"Task 2","Task 2 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (3,3,"Task 3","Task 3 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (4,3,"Task 4","Task 4 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (5,3,"Task 5","Task 5 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (6,3,"Task 6","Task 6 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (7,3,"Task 7","Task 7 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (8,3,"Task 8","Task 8 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (9,3,"Task 9","Task 9 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now)),
        new (10,3,"Task 10","Task 10 Description",DateTime.Now,true,"High",DateOnly.FromDateTime(DateTime.Now))
    
    ];

    //this makes the endpoint available to the application ie extendable
    public static  RouteGroupBuilder MapTasksEndpoints(this WebApplication app)
    {     
        var group = app.MapGroup("/tasks");

        group.MapGet("/", () => tasks);

        group.MapGet("/{id}", (int Id)=> 
        {
            TaskDto? task  = tasks.Find(task => task.taskId == Id);
            return  task is null ? Results.NotFound() : Results.Ok(task);
            
        }).WithName(GetTaskEndpointName);


        //POST request

        group.MapPost("/", (CreateTaskDto newTask) =>
        {
            if(string.IsNullOrEmpty(newTask.TaskTitle)){
                return Results.BadRequest("Task title  is required");
            }
            TaskDto task = new TaskDto(
                tasks.Count + 1,
                newTask.userId,
                newTask.TaskTitle,
                newTask.TaskDescription,
                newTask.TaskDate,
                newTask.Status,
                newTask.TaskPriority,
                newTask.dateCreated
            );
            tasks.Add(task);    
        return Results.CreatedAtRoute(GetTaskEndpointName, new {id=task.taskId },new {Task = "Task Created Successfully " + task});
        }).WithParameterValidation();//to recognise Data Validations


        //PUT request 
        //not thread safe for now

        group.MapPut("/{id}", (int id , UpdateTaskDto updatedTask) =>
        {
            var index =  tasks.FindIndex(task => task.taskId == id);

            if(index == -1) return Results.NotFound("Task not found");
            tasks[index]= new TaskDto(
                id,
                updatedTask.userId,
                updatedTask.TaskTitle,
                updatedTask.TaskDescription,
                updatedTask.TaskDate,
                updatedTask.Status,
                updatedTask.TaskPriority,
                updatedTask.dateCreated
            );

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
