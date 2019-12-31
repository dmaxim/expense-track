
using Microsoft.AspNetCore.Http;

namespace Barney.WebUI.Infrastructure
{
    public static class RequestExtensions
    {
        public static string GetPath(this HttpRequest request)
        {
            return $"{request.Scheme}://{request.Host}{request.Path}";
        }

        public static string CurrentUserName(this HttpRequest request)
        {


            if (request.HttpContext.User?.Identity != null && !string.IsNullOrWhiteSpace(request.HttpContext.User.Identity.Name))
            {
                var test = request.HttpContext.User.Claims;
                return request.HttpContext.User.Identity.Name;
            }

            return "Unauthenticated user";
        }
    }
}
