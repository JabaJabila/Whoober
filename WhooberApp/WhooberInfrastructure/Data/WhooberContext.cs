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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().HasOne(p => p.SavedCard);
            modelBuilder.Entity<Passenger>().HasOne(p => p.PaymentMethod);
            modelBuilder.Entity<Driver>().HasOne(d => d.SavedCard);
            modelBuilder.Entity<Driver>().HasOne(d => d.PaymentMethod);
            modelBuilder.Entity<Driver>().Property(d => d.State)
                .HasConversion(new EnumToStringConverter<DriverState>());
            
            modelBuilder.Entity<Passenger>().ToTable("Passengers");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            base.OnModelCreating(modelBuilder);
        }
    }
}