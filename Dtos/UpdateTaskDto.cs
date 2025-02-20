namespace TaskApp.Dtos;

public record class UpdateTaskDto(    int userId,
    string TaskTitle, 
    string TaskDescription,
    DateTime TaskDate, 
    bool Status,
    string TaskPriority, 
    DateOnly dateCreated
    );


