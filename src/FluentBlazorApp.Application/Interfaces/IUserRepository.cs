using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserByUsernameAsync(string username);
}