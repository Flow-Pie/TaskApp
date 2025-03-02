namespace TaskApp.Dtos;
public record UserDetailsDto(
    int UserId,
    string Username,
    string Password,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    DateTime DateRegistered
);