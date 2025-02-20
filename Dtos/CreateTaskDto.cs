namespace TaskApp.Dtos;

//CreateTaskDto should not have taskId as it is auto generated
public record class CreateTaskDto(  
    int userId,
    string TaskTitle, 
    string TaskDescription,
    DateTime TaskDate, 
    bool Status,
    string TaskPriority, 
    DateOnly dateCreated
    );

