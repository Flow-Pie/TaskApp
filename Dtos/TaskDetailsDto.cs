namespace TaskApp.Dtos;

public  record TaskDetailsDto(
    int TaskId, 
    int UserId,
    string TaskTitle, 
    string TaskDescription,
    DateTime TaskDate, 
    bool Status,
    string TaskPriority, 
    DateOnly DateCreated
    );

   