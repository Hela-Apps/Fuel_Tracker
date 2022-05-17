using ClassifiedAds.Tools.ExtractExcel.Readers;
using ClassifiedAds.Tools.ExtractExcel.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ClassifiedAds.Tools.ExtractExcel
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", true);
                    config.AddJsonFile($"appsettings.{GetEnvironement()}.json", true, reloadOnChange: true);
                    if (args != null) config.AddCommandLine(args);
                })
                .ConfigureServices((hostingContext, services) =>
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    services.AddTransient<CityReader>();
                    services.AddHostedService<StartupHostedService>();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration);
                    logging.AddConsole();
                });

            await builder.RunConsoleAsync();
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
