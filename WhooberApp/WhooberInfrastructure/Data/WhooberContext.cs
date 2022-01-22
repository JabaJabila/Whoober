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
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.SavedCard);
            modelBuilder.Entity<Passenger>().Ignore(p => p.PaymentMethod);
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.Location);
            modelBuilder.Entity<Passenger>().HasOne(p => p.Rating);

            modelBuilder.Entity<Driver>().OwnsOne(d => d.SavedCard);
            modelBuilder.Entity<Driver>().Ignore(d => d.PaymentMethod);
            modelBuilder.Entity<Driver>().HasOne(d => d.Car);
            modelBuilder.Entity<Driver>().OwnsOne(d => d.Location);
            modelBuilder.Entity<Driver>().HasOne(d => d.Rating);
            modelBuilder.Entity<Driver>().Property(d => d.State)
                .HasConversion(new EnumToStringConverter<DriverState>());

            modelBuilder.Entity<Route>().Ignore(r => r.Locations);

            modelBuilder.Entity<Order>().HasOne(o => o.Route);
            modelBuilder.Entity<Order>().HasOne(o => o.Passenger);
            modelBuilder.Entity<Order>().Property(o => o.State)
                .HasConversion(new EnumToStringConverter<OrderState>());
            modelBuilder.Entity<Order>().Property(o => o.CarLevel)
                .HasConversion(new EnumToStringConverter<CarLevel>());

            modelBuilder.Entity<Trip>().HasOne(t => t.Order);
            modelBuilder.Entity<Trip>().HasOne(t => t.Car);
            modelBuilder.Entity<Trip>().HasOne(t => t.Driver);
            modelBuilder.Entity<Trip>().Property(t => t.State)
                .HasConversion(new EnumToStringConverter<TripState>());

            modelBuilder.Entity<Rating>().HasMany(r => r.Rates)
                .WithOne(r => r.FromRating);
            modelBuilder.Entity<Rating>().Ignore(r => r.AverageScore);

            modelBuilder.Entity<Passenger>().ToTable("Passengers");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Trip>().ToTable("Trips");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Rate>().ToTable("Rates");
            modelBuilder.Entity<Rating>().ToTable("Ratings");
            base.OnModelCreating(modelBuilder);
        }
    }
}