using JWS.Contracts.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace JWS.Infrastructure.Configures
{
	public static class Middleware
	{
		public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder)
		{
			builder.UseMiddleware<ExceptionMiddleware>();

			builder.Use(async (context, next) =>
			{
				await next();

				if (context.Response.StatusCode == 404)
				{
					context.Request.Path = "/index.html";
					await next();
				}
			});

			return builder;
		}
	}
}
