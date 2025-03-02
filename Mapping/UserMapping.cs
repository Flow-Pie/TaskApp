using System.Data.Common;
using Microsoft.AspNetCore.Identity;
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

    public static User ToUserEntity(this CreateUserDto newUser)
    {
        return new User()
        {
            Username = newUser.Username,
            Password = newUser.Password,
            Email = newUser.Email,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            Role = newUser.Role,
            DateRegistered = newUser.DateRegistered
        };
    }
    public static User ToUserEntity(this UpdateUserDto updateUser, int id)
    {
        return new User()
        {
            UserId = id,
            Username = updateUser.Username,
            Password = updateUser.Password,
            Email = updateUser.Email,
            FirstName = updateUser.FirstName,
            LastName = updateUser.LastName,
            Role = updateUser.Role,
            DateRegistered = updateUser.DateRegistered
        };
    }
}