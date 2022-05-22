using Entity.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StationDomain
{
    public class StationService: IStationService
    {
        private readonly IStationRepository _stationRepository;
        public StationService(IStationRepository stationRepository)
        {
            _stationRepository = stationRepository;
        }

        public async Task<Station> Create(Station station)
        {
           return await _stationRepository.Add(station);
        }

        public async Task<Station> Get(int id)
        {
            return await _stationRepository.GetById(id);
        }

        public async Task<List<Station>> GetStationByCity (int cityId)
        {
            return await _stationRepository.GetStationListByCity(cityId);
        }
    }
}
