
using ClassifiedAds.Tools.InsertMaster.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BruCensus.Tools.CreateQuestionnaire.Service
{
    public class StartupHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime lifeTime;
        private readonly ICitiesExtractor citiesExtractor;

        public StartupHostedService(
            ILogger<StartupHostedService> logger,
            IHostApplicationLifetime lifeTime,
             ICitiesExtractor citiesExtractor)
        {
            _logger = logger;
            this.lifeTime = lifeTime;
            this.citiesExtractor = citiesExtractor;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting IHostedService registered in Startup");

            try
            {
                await citiesExtractor.ExecuteQurstionInsert();
                _logger.LogInformation("Cities Inserting Process Completed Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("found an error: " + ex.Message);
                _logger.LogError("found an error: " + ex.InnerException);
                throw ex.InnerException;
            }
            finally
            {
                lifeTime.StopApplication();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StoppingIHostedService registered in Startup");
            return Task.CompletedTask;
        }
    }
}
