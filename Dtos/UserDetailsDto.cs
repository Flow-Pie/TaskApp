namespace TaskApp.Dtos;
public class UserDetailsDto(
    int UserId,
    string Username,
    string password,
    string Email,
    string FirstName,
    string LastName,
    string Role,
    DateTime DateRegistered
);