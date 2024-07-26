namespace Web_Api.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // İşlem öncesi
            await _next(context);
            // İşlem sonrası
        }
    }
}
