using Entity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FuelTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Context
{
    public class AthenticationContext : IdentityDbContext
    {
        public AthenticationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
