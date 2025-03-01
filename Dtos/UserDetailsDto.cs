namespace TaskApp.Dtos;
public record class UserDetailsDto(
    int UserId,
    string Username,
    string Password,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    DateTime DateRegistered
);