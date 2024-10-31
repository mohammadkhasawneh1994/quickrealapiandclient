using Microsoft.EntityFrameworkCore;

namespace Robbochinni.Driver.Repo.Entities
{
    internal class DbCtx : DbContext
    {
        public DbCtx(DbContextOptions options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(i => i.Role)
                .WithMany(i => i.Users)
                .HasForeignKey(i => i.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Location>()
                .Property(i => i!.Latitude)
                .HasPrecision(18, 16);

            modelBuilder.Entity<Location>()
                .Property(i => i!.Longitude)
                .HasPrecision(18, 16);

            modelBuilder.Entity<Trip>()
                .HasOne(i => i.Requester)
                .WithMany(i => i.Requests)
                .HasForeignKey(i => i.RequesterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasOne(i => i.Driver)
                .WithOne(i => i.Car)
                .HasForeignKey<Car>(i => i.DriverId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
