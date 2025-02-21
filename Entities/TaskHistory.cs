namespace TaskApp.Entities;
public class TaskHistory{
    public int TaskHistoryId { get; set; }
    public required int TasksId { get; set; }
    
    public enum Status {
       Pending,
        Completed
    }
    
    public required DateTime UpdatedAt { get; set; }

    public Tasks? Tasks { get; set; }
    
}