using System.Security.Claims;

namespace sw_project.Tests.TestHelpers;

internal static class ClaimsPrincipalFactory
{
    public static ClaimsPrincipal CreateWithUserId(string userId)
    {
        var identity = new ClaimsIdentity(
            new[] { new Claim(ClaimTypes.NameIdentifier, userId) },
            authenticationType: "TestAuth");

        return new ClaimsPrincipal(identity);
    }
}
