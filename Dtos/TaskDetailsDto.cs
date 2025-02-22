namespace TaskApp.Dtos;

public  record class TaskDetailsDto(
    int taskId, 
    int userId,
    string TaskTitle, 
    string TaskDescription,
    DateTime TaskDate, 
    bool Status,
    string TaskPriority, 
    DateOnly dateCreated
    );

   