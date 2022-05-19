using Entity.Context;
using Entity.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class StationRepository : IStationRepository
    {
        protected FuelTrackerDbContext _context;
        public StationRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Station entity)
        {
            await _context.Set<Station>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<Station, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Station> FirstOrDefault(Expression<Func<Station, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Station>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Station> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Station>> GetWhere(Expression<Func<Station, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Station entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Station entity)
        {
            throw new NotImplementedException();
        }
    }
}
