using Entity.Models;
using Entity.Context;
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
    public class DistrictRepository : IDistrictRepository
    {
        protected FuelTrackerDbContext _context;
        public DistrictRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(District entity)
        {
            await _context.Set<District>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<District, bool>> predicate)
         => _context.Set<District>().CountAsync(predicate);

        public Task<District> FirstOrDefault(Expression<Func<District, bool>> predicate)
        => _context.Set<District>().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<District>> GetAll()
        {
            return await _context.Set<District>().ToListAsync();
        }

        public async Task<District> GetById(long id)
        {
            return await _context.Set<District>().FindAsync(id);
        }

        public async Task<IEnumerable<District>> GetWhere(Expression<Func<District, bool>> predicate)
        {
            return await _context.Set<District>().Where(predicate).ToListAsync();
        }

        public Task Remove(District entity)
        {
            _context.Set<District>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(District entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task<int> _countAll() => _context.Set<District>().CountAsync();
    }
}
