using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StationDomain
{
    public interface IStationService
    {
        Task<int> Create(Station station);
    }
}
