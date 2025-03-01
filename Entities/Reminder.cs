using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Entities;

public class Reminder{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ReminderId { get; set; }
    public required int TasksId { get; set; }
    
    public DateTime ReminderDate { get; set; }
    public required DateTime UpdatedAt { get; set; }

    public Tasks? Tasks { get; set; }
    
}