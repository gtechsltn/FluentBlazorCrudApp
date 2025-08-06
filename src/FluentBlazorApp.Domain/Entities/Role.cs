namespace FluentBlazorApp.Domain.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string Rolename { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
