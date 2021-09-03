using Core.Entities.Concrete;
using DataAccess.Concrete.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ModelType> ModelTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentCar;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new VehicleImageConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new ColorConfiguration());
            builder.ApplyConfiguration(new ModelConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new ModelTypeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OperationClaimConfiguration());
            builder.ApplyConfiguration(new UserClaimConfiguration());
        }
    }
}
