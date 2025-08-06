using FluentBlazorApp.Domain.Dtos;
using FluentBlazorApp.Domain.Entities;

namespace FluentBlazorApp.Application.Services;

public interface IUserService
{
    Task<User> RegisterUserAsync(string username, string password);
    Task<UserWithRolesDto?> LoginAsync(string username, string password);
}