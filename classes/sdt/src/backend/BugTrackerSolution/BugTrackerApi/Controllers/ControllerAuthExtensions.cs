using System.Security.Claims;

namespace BugTrackerApi.Controllers;

public static class ControllerAuthExtensions
{
    public static string GetName(this ClaimsPrincipal claims)
    {
        return claims.Identity?.Name ?? throw new InvalidOperationException("No Claims Present");
    }
}