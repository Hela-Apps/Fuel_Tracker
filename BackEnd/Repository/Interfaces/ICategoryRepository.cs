using Entity.Models;
using FuelTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        
    }
}
