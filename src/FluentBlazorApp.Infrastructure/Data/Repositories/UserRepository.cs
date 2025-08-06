using FluentBlazorApp.Application.Interfaces;
using FluentBlazorApp.Domain.Dtos;
using FluentBlazorApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorApp.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddUserAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task<UserWithRolesDto?> GetUserByUsernameAsync(string usernameToLower)
    {
        // Get the user by their unique username
#if DEBUG
        var user = await _db.Users
            .Include(u => u.UserRoles) // Include the UserRole join table
                .ThenInclude(ur => ur.Role) // Then include the Role from the UserRole
            .FirstOrDefaultAsync(u => u.UsernameToLower == usernameToLower);
#endif
        // Projecting to a Custom DTO
        var userWithRoles = await _db.Users
            .Where(u => u.UsernameToLower == usernameToLower)
            .Select(u => new UserWithRolesDto
            {
                UserId = u.UserId,
                Username = u.Username,
                HashedPassword = u.HashedPassword,
                Roles = u.UserRoles.Select(ur => ur.Role.Rolename).ToList()
            })
            .FirstOrDefaultAsync();
        return userWithRoles;
    }
}