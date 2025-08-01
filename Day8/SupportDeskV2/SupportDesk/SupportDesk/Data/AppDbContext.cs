using Microsoft.EntityFrameworkCore;
using SupportDesk.Models;

namespace SupportDesk.Data
{
    public class AppDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=SupportPro;User=sa;Password=Appa1968@hari7405;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<SupportAgent> SupportAgents => Set<SupportAgent>();
        public DbSet<CustomerProfile> CustomerProfiles => Set<CustomerProfile>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<TicketHistory> TicketHistories => Set<TicketHistory>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Customer>().HasBaseType<User>();
            modelBuilder.Entity<SupportAgent>().HasBaseType<User>();

          
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.CustomerProfile)
                .WithOne(p => p.Customer)
                .HasForeignKey<CustomerProfile>(p => p.CustomerId);

            
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId);

           
            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.SupportAgents)
                .WithMany(a => a.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketSupportAgent",
                    j => j
                        .HasOne<SupportAgent>()
                        .WithMany()
                        .HasForeignKey("SupportAgentsId")
                        .OnDelete(DeleteBehavior.Restrict),
                    j => j
                        .HasOne<Ticket>()
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Restrict)
                );

            
            modelBuilder.Entity<Department>()
                .HasMany(d => d.SupportAgents)
                .WithOne(a => a.Department)
                .HasForeignKey(a => a.DepartmentId);

           
            modelBuilder.Entity<TicketHistory>()
                .HasOne(th => th.Ticket)
                .WithMany(t => t.TicketHistories)
                .HasForeignKey(th => th.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Tickets)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
