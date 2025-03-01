using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.Dtos;


public record UpdateUserDto(
    [Required, StringLength(50)]string Username,
    [Required, MinLength(8),PasswordPropertyText]string Password,
    [Required,EmailAddress]string Email,
    string FirstName,
    string LastName,
    string Role,
    DateTime DateRegistered);