using System.Security.Claims;

namespace Api.Controllers.util
{
    public static class JWTUid
    {
        public static int GetUserId(this ClaimsPrincipal user) => 
            int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new UnauthorizedAccessException("User has no id in token"));
    }
}
