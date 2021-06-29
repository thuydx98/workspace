using JWS.Contracts.EntityFramework;
using JWS.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using JWS.Data;

namespace JWS.Infrastructure.Configures
{
	public static class Database
	{
		public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
		{
			var dbConnection = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");

			services.AddDbContext<ApplicationContext>(opt => opt.UseNpgsql(dbConnection));
			services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationContext>>();

			return services;
		}
	}
}
