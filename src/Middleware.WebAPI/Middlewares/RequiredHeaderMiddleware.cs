namespace Middleware.WebAPI.Middlewares
{
    public class RequiredHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _requiredHeader;

        public RequiredHeaderMiddleware(RequestDelegate next, string requiredHeader)
        {
            _next = next;
            _requiredHeader = requiredHeader;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(_requiredHeader))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync( new { ErrorMessage = $"Bad Request: The '{_requiredHeader}' header is required." });
                return;
            }

            await _next(context);
        }
    }
}
