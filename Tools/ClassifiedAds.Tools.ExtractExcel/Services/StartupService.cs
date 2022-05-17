using ClassifiedAds.Tools.ExtractExcel.Readers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace ClassifiedAds.Tools.ExtractExcel.Services
{
    public class StartupHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly CityReader cityReader;
        private readonly IConfiguration configuration;

        public StartupHostedService(
            ILogger<StartupHostedService> logger,
            IConfiguration configuration,
            CityReader cityReader)
        {
            _logger = logger;
            this.cityReader = cityReader;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting IHostedService registered in Startup");
            cityReader.Read();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StoppingIHostedService registered in Startup");
            return Task.CompletedTask;
        }
    }
}
