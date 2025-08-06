namespace FluentBlazorApp.Infrastructure.Security
{
    public interface IPasswordHasher
    {
        static abstract string HashPassword(string password);
        static abstract string HashPassword(string password, string salt);
        static abstract bool VerifyPassword(string password, string hashedPassword);
    }
}