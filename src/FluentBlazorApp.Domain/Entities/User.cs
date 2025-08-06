namespace FluentBlazorApp.Domain.Entities;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
    public string UsernameToLower { get; set; }
    public string EmailToLower { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}