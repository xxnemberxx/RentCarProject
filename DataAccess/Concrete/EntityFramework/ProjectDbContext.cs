using Core.Entities.Concrete;
using DataAccess.Concrete.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentCar;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new VehicleConfiguration())
                .ApplyConfiguration(new VehicleImageConfiguration())
                .ApplyConfiguration(new BrandConfiguration())
                .ApplyConfiguration(new ColorConfiguration())
                .ApplyConfiguration(new CustomerConfiguration())
                .ApplyConfiguration(new ModelConfiguration())
                .ApplyConfiguration(new ReservationConfiguration())
                .ApplyConfiguration(new ModelTypeConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new OperationClaimConfiguration())
                .ApplyConfiguration(new UserClaimConfiguration());
        }
    }
}
