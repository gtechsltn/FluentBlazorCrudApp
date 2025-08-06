namespace FluentBlazorApp.Domain.Dtos;

public class UserWithRolesDto
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string HashedPassword { get; set; }
    public ICollection<string> Roles { get; set; }
}