using TaskApp.Entities;
using TaskApp.Dtos;
using TaskApp.Endpoints;



namespace TaskApp.Mapping;

public static class TaskMapping
{
    //To Entity convert tasks to entity for insertion to db
    public static Tasks ToEntity(this CreateTaskDto newTask )
    {
          return  new Tasks()
            {               
                UserId = newTask.userId,
                TaskTitle = newTask.TaskTitle,
                TaskDescription = newTask.TaskDescription,
                TaskDate = newTask.TaskDate,
                Status = newTask.Status,
                TaskPriority = newTask.TaskPriority,
                dateCreated = newTask.dateCreated
            };
    }

    public static TaskDetailsDto ToTaskDetailsDto(this Tasks task) //this makes toDto and extension method and
    //  also makes task to have the definition of toDto.
    {
        return new TaskDetailsDto(
        
            task.TaskId,
            task.UserId,
            task.TaskTitle,
            task.TaskDescription,
            task.TaskDate,
            task.Status,
            task.TaskPriority,
            task.dateCreated
        
        );
    }

    //overriden to entity method
        public static Tasks ToEntity(this UpdateTaskDto newTask, int id )
        {
            return  new Tasks()
                {
                    TaskId = id,
                    UserId = newTask.userId,
                    TaskTitle = newTask.TaskTitle,
                    TaskDescription = newTask.TaskDescription,
                    TaskDate = newTask.TaskDate,
                    Status = newTask.Status,
                    TaskPriority = newTask.TaskPriority,
                    dateCreated = newTask.dateCreated
                };
        }
}
