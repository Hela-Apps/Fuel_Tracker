using Domain.ViewModel;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonDomain
{
    public interface ICommonService
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<District>> GetAllDistricts();
        Task<IEnumerable<City>> GetAllCitiesbyDistrictId(int id);
    }
}
