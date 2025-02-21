namespace TaskApp.Entities;

public class Reminder{
    public int ReminderId { get; set; }
    public required int TasksId { get; set; }
    
    public DateTime ReminderDate { get; set; }
    public required DateTime UpdatedAt { get; set; }

    public Tasks? Tasks { get; set; }
    
}