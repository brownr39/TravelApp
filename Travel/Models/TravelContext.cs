


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Travel.Models
{
    public class TravelContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Startup.Configuration["Data:DefaultConnection:TravelConnectionString"];
            optionsBuilder.UseSqlServer(connString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Trip> Trip { get; set; }
        public DbSet<Stop> Stops { get; set; }

        public TravelContext()
        {
            Database.EnsureCreated();
        }

        public static implicit operator TravelContext(TripsRepository v)
        {
            throw new NotImplementedException();
        }
    }
}
