using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
   public  class CityRepository : ICityRepository
    {
        protected FuelTrackerDbContext _context;
        public CityRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(City entity)
        {
            await _context.Set<City>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<City, bool>> predicate)
         => _context.Set<City>().CountAsync(predicate);

        public Task<City> FirstOrDefault(Expression<Func<City, bool>> predicate)
        => _context.Set<City>().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Set<City>().ToListAsync();
        }

        public async Task<IEnumerable<City>> GetAllbyDistrictId(int id)
        {
            return await _context.Set<City>().Where(x=> x.DistrictId == id).ToListAsync();
        }
        public async Task<City> GetById(long id)
        {
            return await _context.Set<City>().FindAsync(id);
        }

        public async Task<IEnumerable<City>> GetWhere(Expression<Func<City, bool>> predicate)
        {
            return await _context.Set<City>().Where(predicate).ToListAsync();
        }

        public Task Remove(City entity)
        {
            _context.Set<City>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(City entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task<int> _countAll() => _context.Set<City>().CountAsync();
    }
}
