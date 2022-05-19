using Entity.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class StationFuelDetailRepository : IStationFuelDetailRepository
    {
        public Task<StationFuelDetail> Add(StationFuelDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<StationFuelDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<StationFuelDetail> FirstOrDefault(Expression<Func<StationFuelDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StationFuelDetail>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<StationFuelDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StationFuelDetail>> GetWhere(Expression<Func<StationFuelDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(StationFuelDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(StationFuelDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
