using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassifiedAds.Tools.InsertMaster.Service
{
    public interface ICitiesExtractor
    {
        Task ExecuteQurstionInsert();
        Task InsertCities(List<City> cities);
    }
}
