using FluentBlazorApp.Application.Interfaces;
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

    public async Task<User?> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUsernameAsync(username);
        if (user == null || !PasswordHasher.VerifyPassword(password, user.HashedPassword))
        {
            return null;
        }
        return user;
    }
}