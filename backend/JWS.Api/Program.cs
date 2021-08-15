using JWS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace JWS.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            if (Environment.GetEnvironmentVariable("NEED_MIGRATE") == "true")
            {
                var serviceProvider = hostBuilder.Services.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider;
                var dbContext = serviceProvider.GetRequiredService<ApplicationContext>();

                await dbContext.Database.MigrateAsync();
            }

            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
