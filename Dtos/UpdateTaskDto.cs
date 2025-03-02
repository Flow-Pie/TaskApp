using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace TaskApp.Dtos;

public record UpdateTaskDto(   
    [Required] [Range(-100,100)] int UserId,//-indentifiers are just for seed data validations
    [Required]string TaskTitle, 
    [Required]string TaskDescription,
    [Required]DateTime TaskDate, 
    [DefaultValue(false)]bool Status,
    string TaskPriority, 
    DateOnly DateCreated
    );


