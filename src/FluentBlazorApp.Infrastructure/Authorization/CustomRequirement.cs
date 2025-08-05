using Microsoft.AspNetCore.Authorization;

namespace FluentBlazorApp.Infrastructure.Authorization;

public class CustomRequirement : IAuthorizationRequirement
{
    public CustomRequirement(string requiredPermission)
    {
        RequiredPermission = requiredPermission;
    }
    public string RequiredPermission { get; }
}
