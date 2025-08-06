using FluentBlazorApp.Infrastructure.Security;

namespace FluentBlazorApp.Tests
{
    public class PasswordHasherTests
    {
        [Fact]
        public void GenerateSalt_NormalPass_CanGenerate()
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            Console.WriteLine($"Generated Salt: {salt}");
            Assert.NotNull(salt);
        }

        [Fact]
        public void HashPasswordWithSalt_NormalPass_Returns_CanHashed()
        {
            var password = "Abc@123$";
            var salt = "$2a$12$etl9Yao5aI1TgwfXkLnv4u";
            var hashedPassword = PasswordHasher.HashPassword(password, salt);
            Assert.NotNull(hashedPassword);
            Assert.NotEqual(password, hashedPassword);
        }

        [Fact]
        public void HashPassword_NormalPass_Returns_CanHashed()
        {
            var password = "Abc@123$";
            var hashedPassword = PasswordHasher.HashPassword(password);
            Assert.NotNull(hashedPassword);
            Assert.NotEqual(password, hashedPassword);
        }

        [Fact]
        public void VerifyPassword_NormalPass_Returns_CanVerify()
        {
            var password = "Abc@123$";
            var hashedPassword = "$2a$12$7nvD6HXBR0yrEAZukvQbh.aaR.rePrnmjVpA2VoCbcKEVw9h2FI/i";
            var isValid = PasswordHasher.VerifyPassword(password, hashedPassword);
            Assert.True(isValid);
        }
    }
}
