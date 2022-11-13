using Microsoft.EntityFrameworkCore;
using spinning_wheel.Core.Domain;

namespace spinning_wheel.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<SpinningWheel> spinningWheels { get; set; }
        public DbSet<WheelSegment> wheelSegments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpinningWheel>().HasKey(e => e.Id);
            modelBuilder.Entity<SpinningWheel>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<WheelSegment>().HasKey(e => e.Id);
            modelBuilder.Entity<SpinningWheel>().Property(e => e.Id)
            .HasValueGenerator<SeqIdValueGenerator> ()
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<WheelSegment>().Property(e => e.Id)
            .HasValueGenerator<SeqIdValueGenerator>()
            .ValueGeneratedOnAdd();
        }
    }
}
