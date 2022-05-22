using AutoMapper;
using Domain.ViewModel;
using Entity.Models;
using Newtonsoft.Json;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CommonDomain
{
    public class CommonService : Profile, ICommonService
    {
      
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICompanyRepository _companyRepository;
        public CommonService(
            ICategoryRepository categoryRepository,
            IDistrictRepository districtRepository,
            ICityRepository cityRepository,
            ICompanyRepository companyRepository)
        {
           
            _categoryRepository = categoryRepository;
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;
            _companyRepository = companyRepository;
        }
                
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();
            return categories.Where(x => x.IsActive == true);
        }       

        public async Task<IEnumerable<District>> GetAllDistricts()
        {
            var conditions = await _districtRepository.GetAll();
            return conditions.Where(x => x.IsActive == true);
        }
        public async Task<IEnumerable<City>> GetAllCitiesbyDistrictId(int id)
        {
            var conditions = await _cityRepository.GetAllbyDistrictId(id);
            return conditions.Where(x => x.IsActive == true);
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            var conditions = await _companyRepository.GetAll();
            return conditions.Where(x => x.IsActive == true);
        }
    }
}
