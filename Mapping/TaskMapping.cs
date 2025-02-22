using TaskApp.Entities;
using TaskApp.Dtos;
using TaskApp.Endpoints;


namespace TaskApp.Mapping;

public static class TaskMapping
{
    public static Tasks ToEntity(this CreateTaskDto newTask )
    {
          return  new Tasks()
            {
                TaskId = TasksEndpoints.tasks.Count +1,
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
