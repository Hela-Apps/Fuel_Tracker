using Entity.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IStationRepository: IAsyncRepository<Station>
    {
    }
}
