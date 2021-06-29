using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using JWS.Common.ApiResponse;

namespace JWS.Infrastructure.Configures
{
	public static class Mediator
	{
		public static IServiceCollection AddMediator(this IServiceCollection services)
		{
			return services.AddMediatR(Assembly.GetExecutingAssembly());
		}

		public static void AddService<TRequest, TImplementation>(this IServiceCollection services)
			where TRequest : class, IRequest<ApiResult>
			where TImplementation : class, IRequestHandler<TRequest, ApiResult>
		{
			services.AddScoped<IRequestHandler<TRequest, ApiResult>, TImplementation>();
		}
	}
}
