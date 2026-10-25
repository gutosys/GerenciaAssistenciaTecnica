using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GerenciaAssistenciaTecnica.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var gerenciaAssistenciaTecnicaContext = services.GetRequiredService<GerenciaAssistenciaTecnicaContext>();
                    GerenciaAssistenciaTecnicaContextSeed.SeedAsync(gerenciaAssistenciaTecnicaContext)
                    .Wait();

                    //var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    //AppIdentityDbContextSeed.SeedAsync(userManager).Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
