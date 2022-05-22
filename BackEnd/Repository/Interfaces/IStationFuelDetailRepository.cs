using Entity.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStationFuelDetailRepository : IAsyncRepository<StationFuelDetail>
    {
        Task<List<StationFuelDetail>> GetStationDetailByStation(int stationId);
        Task<StationFuelDetail> Add(StationFuelDetail entity);
        Task<StationFuelDetail> UpdateStatus(int id, bool status);
        Task<StationFuelDetail> GetbyStationId(int stationId);
        Task<List<FuelSearchResults>> FuelSearchByCity(int categoryId, int cityId);
    }
}
