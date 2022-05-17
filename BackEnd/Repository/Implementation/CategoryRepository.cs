using Entity.Models;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CategoryRepository :  ICategoryRepository
    {
        protected FuelTrackerDbContext _context;
        public CategoryRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Category entity)
        {
            await _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<Category, bool>> predicate)
         => _context.Set<Category>().CountAsync(predicate);

        public Task<Category> FirstOrDefault(Expression<Func<Category, bool>> predicate)
        => _context.Set<Category>().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category> GetById(long id)
        {
            return await _context.Set<Category>().FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetWhere(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Set<Category>().Where(predicate).ToListAsync();
        }

        public Task Remove(Category entity)
        {
            _context.Set<Category>().Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task Update(Category entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public Task<int> _countAll() => _context.Set<Category>().CountAsync();
    }
}
