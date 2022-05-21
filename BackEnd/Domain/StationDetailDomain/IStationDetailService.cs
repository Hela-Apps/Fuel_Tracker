using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StationDetailDomain
{
   public  interface IStationDetailService
    {
        Task<List<StationFuelDetail>> GetStationDetailList(int stationId);
        Task<StationFuelDetail> AddStationDetail(StationFuelDetail stationFuelDetail);
        Task<List<StationFuelDetail>> AddAutomatedStationDetails(int stationId);
        Task<StationFuelDetail> UpdateFuelAvailabilityStatus(int fuelDetailId, bool status);
    }
}
