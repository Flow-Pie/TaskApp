namespace TaskApp.Entities;
public class Calendar{
    public int CalendarId { get; set; }
    public required int TasksId { get; set; }
    public required string StartTime { get; set; }
    public required string EndTime { get; set; }
    public required string EventTitle { get; set; }

    public Tasks? Tasks { get; set; }

}