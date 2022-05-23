using Microsoft.EntityFrameworkCore;
using Proj1.with_relation.models;

namespace Proj1.with_relation.data
{
    public class PjContext : DbContext
    {
        public PjContext()
        {

        }
        public PjContext(DbContextOptions<PjContext> options) : base(options)
        {

        }
        public DbSet<PassengerR> passengerRs { get; set; } = null!;
        public DbSet<BookingR> bookingRs { get; set; } = null!;
        public DbSet<FlightR> flightRs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerR>()
            .HasMany(p => p.flightRs)
            .WithMany(p => p.passengerRs)
            .UsingEntity<BookingR>();

            modelBuilder.Entity<FlightR>()
            .HasMany(p => p.passengerRs)
            .WithMany(p => p.flightRs)
            .UsingEntity<BookingR>();
        }
    }
}
