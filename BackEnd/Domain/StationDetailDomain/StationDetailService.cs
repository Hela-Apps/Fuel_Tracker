using Entity.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StationDetailDomain
{
    public class StationDetailService : IStationDetailService
    {
        private readonly IStationFuelDetailRepository _stationFuelDetailRepository;
        private readonly ICategoryRepository _categoryRepository;

        public StationDetailService(IStationFuelDetailRepository stationFuelDetailRepository, ICategoryRepository categoryRepository)
        {
            _stationFuelDetailRepository = stationFuelDetailRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<StationFuelDetail>> GetStationDetailList(int stationId)
        {
            return await _stationFuelDetailRepository.GetStationDetailByStation(stationId);
        }
        public async Task<StationFuelDetail> AddStationDetail(StationFuelDetail  stationFuelDetail)
        {
            return await _stationFuelDetailRepository.Add(stationFuelDetail);
        }

        public async Task<List<StationFuelDetail>> AddAutomatedStationDetails(int stationId)
        {
            var detailList = new List<StationFuelDetail>();
            var stationDetailList = await _categoryRepository.GetAll();
            if (stationDetailList != null)
            {
                foreach (var stationDetail in stationDetailList)
                {
                    var detail = new StationFuelDetail
                    {
                        Availability = false,
                        CategoryId = stationDetail.Id,
                        StationId = stationId,
                        IsActive = true,
                        LastUpdatedTime = DateTime.Now.ToUniversalTime()
                    };
                    await _stationFuelDetailRepository.Add(detail);
                    detailList.Add(detail);
                }

            }
            return detailList;
        }

        public async Task<StationFuelDetail> UpdateFuelAvailabilityStatus(int fuelDetailId, bool status)
        {
           return await _stationFuelDetailRepository.UpdateStatus(fuelDetailId, status);
        }


    }
}
