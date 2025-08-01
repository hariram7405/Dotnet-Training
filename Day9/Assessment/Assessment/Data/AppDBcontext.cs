using Assessment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BugTrackerLite;User=sa;Password=Appa1968@hari7405;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketTag>().HasKey(tt => new { tt.TicketId, tt.TagId });
            modelBuilder.Entity<TicketTag>().HasOne(tt => tt.Ticket).WithMany(t => t.TicketTags).
                HasForeignKey(tt => tt.TicketId);

            modelBuilder.Entity<TicketTag>().HasOne(tt => tt.Tag).WithMany(t => t.TicketTags).
                HasForeignKey(tt => tt.TagId);




        }
    }
}
