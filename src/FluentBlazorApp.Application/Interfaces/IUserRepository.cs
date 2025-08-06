using FluentBlazorApp.Domain.Dtos;
using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<UserWithRolesDto?> GetUserByUsernameAsync(string usernameToLower);
}