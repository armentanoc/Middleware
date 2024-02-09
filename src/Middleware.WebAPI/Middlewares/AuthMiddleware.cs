
namespace Middleware.WebAPI.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("LoggedUser", out var loggedUserHeader))
            {
                string loggedUser = loggedUserHeader.ToString();

                if (loggedUser.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    await _next(context);
                    return;
                }
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(new { ErrorMessage = "Unauthorized: You must be an admin to execute an operation on this API." });
        }
    }
}
