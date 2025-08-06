namespace FluentBlazorApp.Domain.Entities;

public class UserRole
{
    // Foreign key properties
    public int UserId { get; set; }
    public int RoleId { get; set; }

    // Navigation properties to the parent entities
    public User User { get; set; }
    public Role Role { get; set; }
}
