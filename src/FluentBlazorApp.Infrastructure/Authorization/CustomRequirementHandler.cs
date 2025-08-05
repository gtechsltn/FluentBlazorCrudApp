using Microsoft.AspNetCore.Authorization;

namespace FluentBlazorApp.Infrastructure.Authorization;

public class CustomRequirementHandler : AuthorizationHandler<CustomRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomRequirement requirement)
    {
        // Kiểm tra xem người dùng có được xác thực hay không
        if (!context.User.Identity?.IsAuthenticated ?? false)
        {
            return Task.CompletedTask;
        }

        // Logic kiểm tra vai trò hoặc quyền tùy chỉnh
        if (context.User.HasClaim("Permission", requirement.RequiredPermission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
