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
    public class StationFuelDetailRepository : IStationFuelDetailRepository
    {
        protected FuelTrackerDbContext _context;
        public StationFuelDetailRepository(FuelTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<StationFuelDetail> Add(StationFuelDetail entity)
        {
            await _context.Set<StationFuelDetail>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
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

        public async Task<List<StationFuelDetail>> GetStationDetailByStation(int stationId)
        {
            return await _context.StationFuelDetail.Where(x => x.StationId == stationId && x.IsActive == true).ToListAsync();
        }
        public async Task<StationFuelDetail> UpdateStatus(int id, bool status)
        {
            var entity = await _context.StationFuelDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
            entity.Availability = status;
            entity.LastUpdatedTime = DateTime.Now.ToUniversalTime();
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<StationFuelDetail> GetbyStationId(int stationId)
        {
            return await _context.StationFuelDetail.Where(x => x.StationId == stationId).FirstOrDefaultAsync();
        }

        public async Task<List<FuelSearchResults>> FuelSearchByCity(int categoryId, int cityId)
        {
            var fuelSearchResult = new FuelSearchResults();

            var results = await (from d in _context.StationFuelDetail
                          join s in _context.Station on d.StationId equals s.Id
                          join c in _context.Category on d.CategoryId equals c.Id
                          where c.Id == categoryId && s.CityId == cityId
                          select new FuelSearchResults { StationName = s.Name, CategoryName = c.Name, AvailabilityStatus = d.Availability, CityId = s.CityId, CategoryId = d.CategoryId,LastUpdatedTime = d.LastUpdatedTime }).ToListAsync();
             return results;
        }

    }
}
