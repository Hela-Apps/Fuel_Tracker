using ClassifiedAds.Tools.InsertMaster.ViewModels;
using Entity.Context;
using Entity.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ClassifiedAds.Tools.InsertMaster.Service
{
    public class CitiesExtractor :ICitiesExtractor
    {
        private readonly FuelTrackerDbContext context;
        private readonly IConfiguration configuration;
        private readonly ILogger<CitiesExtractor> logger;
        private readonly IList<string> uniqueIds = new List<string>();

        public CitiesExtractor(FuelTrackerDbContext context, IConfiguration configuration, ILogger<CitiesExtractor> logger)
        {
            this.context = context;
            this.configuration = configuration;
            this.logger = logger;
        }

        public async Task ExecuteQurstionInsert()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    //await CleanDB();//truncating selected tables before inserting question related data
                    FileInfo file = new FileInfo(Assembly.GetExecutingAssembly().Location);

                    string path = file.DirectoryName + configuration.GetValue<string>("FilePath:RootFolder");
                    DirectoryInfo d = new DirectoryInfo(path);
                    FileInfo[] Files = d.GetFiles("*.json");
                    for (int i = 0; i < Files.Length; i++)
                    {
                        var cities = new List<City>();
                        using (StreamReader r = new StreamReader(Files[i].FullName))
                        {
                            logger.LogInformation("Start to read " + Files[i].Name);
                            string json = r.ReadToEnd();
                            cities = JsonConvert.DeserializeObject<List<City>>(json);
                        }
                        await InsertCities(cities);
                        logger.LogInformation("Inserting Successful " + Files[i].Name);

                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        public async Task InsertCities(List<City> cities)
        {
            if (cities.Count != 0)
            {
                foreach (var city in cities)
                {
                    context.City.Add(city);
                }
                await context.SaveChangesAsync();

            }
        }
    }
}
