using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SupportDesk.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, move it out of source code. Use configuration (e.g., appsettings.json or user-secrets)
            optionsBuilder.UseSqlServer("Server=localhost;Database=SupportDeskDB;User=sa;Password=Appa1968@hari7405;TrustServerCertificate=True");
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
