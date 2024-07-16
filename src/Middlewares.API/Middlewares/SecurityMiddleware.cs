namespace Auction.Service.Middlewares;

public class SecurityMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context)
	{
		context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
		context.Response.Headers.Append("X-Frame-Options", "DENY");
		context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
		context.Response.Headers.Append("Content-Security-Policy", "default-src 'self'");
		context.Response.Headers.Append("Referrer-Policy", "no-referrer");

		await next(context);
	}
}