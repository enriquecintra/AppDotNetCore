using System.Security.Claims;
using System.Text.Json;

namespace OPPI.WebApi.Extensions
{
    public static class IdentityExtension
    {
        public static T GetUserContext<T>(this ClaimsPrincipal claimIdentity)
        {
            return JsonSerializer.Deserialize<T>(claimIdentity.FindFirst(ClaimTypes.UserData).Value);
        }
    }
}
