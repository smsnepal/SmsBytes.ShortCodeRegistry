using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace SmsBytes.ShortCodeRegistry.Api.GraphQL.Extensions
{
    public static class UserIdExtensions
    {
        public static string? GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string? GetAuthHeader(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext?.Request.Headers[HeaderNames.Authorization];
        }
    }
}
