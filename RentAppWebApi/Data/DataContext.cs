using Microsoft.EntityFrameworkCore;
using RentAppWebApi.Model;

namespace RentAppWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<LandLord> LandLords { get; set; }
        public DbSet<PhotoOfRealEstate> PhotoOfRealEstates { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewableObject> ReviewableObjects { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
