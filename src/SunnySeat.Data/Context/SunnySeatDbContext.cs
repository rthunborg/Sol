using System.Data.Entity;
using SunnySeat.Core.Entities;

namespace SunnySeat.Data.Context
{
    /// <summary>
    /// Entity Framework database context for Sunny Seat application
    /// Configured for PostgreSQL with PostGIS spatial support
    /// </summary>
    public class SunnySeatDbContext : DbContext
    {
        public SunnySeatDbContext() : base("SunnySeatConnection")
        {
            // Enable lazy loading by default
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public SunnySeatDbContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        // Entity sets for spatial data - will be defined when entities are created
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Patio> Patios { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Prediction> Predictions { get; set; }
        public virtual DbSet<WeatherSlice> WeatherSlices { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Register PostGIS spatial provider for .NET Framework 4.8
            // Configuration will be added when entity configurations are created
            
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Test database connectivity
        /// </summary>
        /// <returns>True if connection successful</returns>
        public bool TestConnection()
        {
            try
            {
                return Database.Exists();
            }
            catch
            {
                return false;
            }
        }
    }
}