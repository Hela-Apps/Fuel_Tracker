using Entity.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStationRepository: IAsyncRepository<Station>
    {
        Task<List<Station>> GetStationListByCity(int cityId);
    }
}
