using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Entities;
public class TaskHistory{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int TaskHistoryId { get; set; }
    public required int TasksId { get; set; }

    public Status TaskStatus { get; set; }
    
    public enum Status {
       Pending,
        Completed
    }
    
    public required DateTime UpdatedAt { get; set; }

    public Tasks? Tasks { get; set; }
    
}