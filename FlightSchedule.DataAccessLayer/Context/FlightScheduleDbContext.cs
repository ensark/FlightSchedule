using FlightSchedule.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightSchedule.DataAccessLayer.Context
{
    public class FlightScheduleDbContext : DbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=FlightSchedule;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedRoutes();
            modelBuilder.SeedFlights();
            modelBuilder.SeedSubscriptions();
        }
    }
}
