using Entity.Models;
using FuelTracker.Domain.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDistrictRepository
    {
        Task<District> GetById(long id);
        Task<District> FirstOrDefault(Expression<Func<District, bool>> predicate);

        Task<int> Add(District entity);
        Task Update(District entity);
        Task Remove(District entity);

        Task<IEnumerable<District>> GetAll();
        Task<IEnumerable<District>> GetWhere(Expression<Func<District, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<District, bool>> predicate);
    }
}
