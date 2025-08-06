using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Dtos;
using FluentBlazorApp.Domain.Entities;
using FluentBlazorApp.Infrastructure.Security;

namespace FluentBlazorApp.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> RegisterUserAsync(string username, string password)
    {
        var hashedPassword = PasswordHasher.HashPassword(password);
        var newUser = new User
        {
            Username = username,
            HashedPassword = hashedPassword
        };
        await _userRepository.AddUserAsync(newUser);
        return newUser;
    }

    public async Task<UserWithRolesDto?> LoginAsync(string username, string password)
    {
        var usernameToLower = username.ToLower();
        var userWithRolesDto = await _userRepository.GetUserByUsernameAsync(usernameToLower);
        var hashedPassword = userWithRolesDto?.HashedPassword ?? string.Empty;
        if (userWithRolesDto == null || !PasswordHasher.VerifyPassword(password, hashedPassword))
        {
            return null;
        }
        return userWithRolesDto;
    }
}