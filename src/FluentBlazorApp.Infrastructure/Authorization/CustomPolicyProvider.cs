using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace FluentBlazorApp.Infrastructure.Authorization;

public class CustomPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public CustomPolicyProvider(IOptions<AuthorizationOptions> options)
    {
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => _fallbackPolicyProvider.GetDefaultPolicyAsync();
    public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => _fallbackPolicyProvider.GetFallbackPolicyAsync();

    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith("HasPermission", StringComparison.OrdinalIgnoreCase))
        {
            var permission = policyName.Substring("HasPermission".Length);
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new CustomRequirement(permission));
            return Task.FromResult(policy.Build());
        }

        return _fallbackPolicyProvider.GetPolicyAsync(policyName);
    }
}