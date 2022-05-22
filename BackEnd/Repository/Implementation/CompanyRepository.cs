using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {
        protected FuelTrackerDbContext _context;
        public CompanyRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }
        public Task<Company> Add(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountWhere(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Company> FirstOrDefault(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Set<Company>().ToListAsync();
        }

        public Task<Company> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetWhere(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
