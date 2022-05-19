using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StationDomain
{
    public interface IStationService
    {
        Task<Station> Create(Station station);
        Task<Station> Get(int id);
    }
}
