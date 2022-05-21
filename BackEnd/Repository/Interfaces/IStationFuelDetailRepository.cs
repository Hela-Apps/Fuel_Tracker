using Entity.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStationFuelDetailRepository : IAsyncRepository<StationFuelDetail>
    {
        Task<List<StationFuelDetail>> GetStationDetailByStation(int stationId);
        Task<StationFuelDetail> Add(StationFuelDetail entity);
    }
}
