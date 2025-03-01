using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Entities;
public class Calendar{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int CalendarId { get; set; }
    public required int TasksId { get; set; }
    public required string StartTime { get; set; }
    public required string EndTime { get; set; }
    public required string EventTitle { get; set; }

    public Tasks? Tasks { get; set; }

}