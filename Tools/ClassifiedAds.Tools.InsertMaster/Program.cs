using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BruCensus.Tools.CreateQuestionnaire
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{GetEnvironement()}.json", true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();


        public static async Task Main(string[] args)
        {
            var startup = new Startup(Configuration);
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", false);
                    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", false, true);
                    config.AddEnvironmentVariables();
                    if (args != null) config.AddCommandLine(args);
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    startup.ConfigureServices(services);
                })
                .UseSerilog()
                .UseEnvironment(GetEnvironement());



            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.WithProperty("App Name", "Serilog Web App Sample")
                .CreateLogger();
            try
            {
                await builder.RunConsoleAsync();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static string GetEnvironement()
        {
            //environment variable is set to "development" for development environment
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(environment))
                environment = "Production";
            return environment;
        }

    }
}
