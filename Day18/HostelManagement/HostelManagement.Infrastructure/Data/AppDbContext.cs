using HostelManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostelManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Students)
                .WithOne(s => s.Room)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Staff>()
                .HasMany(s => s.Students)
                .WithOne(s => s.Staff)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
