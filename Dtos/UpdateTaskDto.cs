using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TaskApp.Dtos;

public record class UpdateTaskDto(   
    [Required] [Range(1,100)] int userId,
    [Required]string TaskTitle, 
    [Required]string TaskDescription,
    [Required]DateTime TaskDate, 
    [DefaultValue(false)]bool Status,
    string TaskPriority, 
    DateOnly dateCreated
    );


