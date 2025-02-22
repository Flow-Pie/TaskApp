using TaskApp.Dtos;
using TaskApp.Entities;
namespace TaskApp.Mapping;

public static class UserMapping
{
    public static UserDetailsDto ToUserDetailsDto(this User user)
    {
        return new UserDetailsDto(
            user.UserId,
            user.Username,
            user.Password,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Role,
            user.DateRegistered
        );
    }
}