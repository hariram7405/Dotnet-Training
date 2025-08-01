using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Models;

public partial class BugTrackerContext : DbContext
{
    public BugTrackerContext()
    {
    }

    public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=localhost;Database=BugTrackerLite;User=sa;Password=Appa1968@hari7405;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CF9ACA27E0996");

            entity.Property(e => e.TagName).HasMaxLength(100);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Tickets__712CC6073B3C796B");

            entity.Property(e => e.Status).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tickets__UserId__3A81B327");

            entity.HasMany(d => d.Tags).WithMany(p => p.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TicketTag__TagId__403A8C7D"),
                    l => l.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TicketTag__Ticke__3F466844"),
                    j =>
                    {
                        j.HasKey("TicketId", "TagId").HasName("PK__TicketTa__A77B099D406B5CBB");
                        j.ToTable("TicketTag");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C1F81C167");

            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
