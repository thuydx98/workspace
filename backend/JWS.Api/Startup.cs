using JWS.Common.Constants.Identity;
using JWS.Infrastructure.Configures;
using JWS.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace JWS.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddUnitOfWork();   // Keep when migrate database

            services.AddMediator();
            services.AddAutoMapper();
            services.AddAuth();
            services.AddHttpClient().AddServices();

            services.AddResponseCaching();
            services.AddHttpContextAccessor();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            app.UseMiddlewares();

            app.UseAuthentication().UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers().RequireAuthorization(Policies.API_SCOPE));
        }
    }
}
