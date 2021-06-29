using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using JWS.Common.Constants.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace JWS.Infrastructure.Configures
{
    public static class Auth
	{
		public static IServiceCollection AddAuth(this IServiceCollection services)
		{
			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.Authority = Environment.GetEnvironmentVariable("JWT_ISSUER");
				options.RequireHttpsMetadata = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					ValidateAudience = false,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero,
				};
			});

			services.AddAuthorization(options =>
			{
				options.AddPolicy(Policies.API_SCOPE, policy =>
				{
					policy.RequireAuthenticatedUser();
					policy.RequireClaim("scope", ApiScopes.Features);
				});
			});

			return services;
		}
	}
}
