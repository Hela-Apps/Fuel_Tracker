using Entity.Models;
using Microsoft.EntityFrameworkCore;
using FuelTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Context
{
    public class FuelTrackerDbContext : DbContext
    {
        public FuelTrackerDbContext(DbContextOptions<FuelTrackerDbContext> options) : base(options)
        { }

        public DbSet<Provience> Provience { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<FuelType> FuelType { get; set; }
        public DbSet<Station> Station { get; set; }
        public DbSet<StationFuelDetail> StationFuelDetail { get; set; }
        public DbSet<Company> Company { get; set; }

    }
}
