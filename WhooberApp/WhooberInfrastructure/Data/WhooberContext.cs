using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhooberCore.Domain.Entities;
using WhooberCore.Domain.Enums;

namespace WhooberInfrastructure.Data
{
    public sealed class WhooberContext : DbContext
    {
        public WhooberContext(DbContextOptions<WhooberContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Trip> Trips { get; }

        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.SavedCard);
            modelBuilder.Entity<Passenger>().Ignore(p => p.PaymentMethod);
            modelBuilder.Entity<Driver>().OwnsOne(d => d.SavedCard);
            modelBuilder.Entity<Driver>().Ignore(d => d.PaymentMethod);
            modelBuilder.Entity<Driver>().HasOne(d => d.Car);
            modelBuilder.Entity<Driver>().Property(d => d.State)
                .HasConversion(new EnumToStringConverter<DriverState>());

            modelBuilder.Entity<Passenger>().ToTable("Passengers");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            base.OnModelCreating(modelBuilder);
        }
    }
}