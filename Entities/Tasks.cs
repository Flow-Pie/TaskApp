using System.ComponentModel.DataAnnotations;

namespace TaskApp.Entities;

public class Tasks 
{
    
    
    [Key]
    public int TaskId { get; set; }
    public required int UserId { get; set; }
    public required string TaskTitle { get; set; }
    public required string TaskDescription { get; set; }
    public DateTime TaskDate { get; set; }
    public bool Status { get; set; }
    public required string TaskPriority { get; set; }
    public DateOnly dateCreated { get; set; }

    public User? User { get; set; }
 
}