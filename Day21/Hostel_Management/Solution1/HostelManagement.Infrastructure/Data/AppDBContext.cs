using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HostelManagement.Core.Entities;


namespace HostelManagement.Infrastructure.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Student> Students { get ; set;}
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Room> Rooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Room>().
            HasMany(s => s.Students).
            WithOne(r => r.Room).
            OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Staff>().
                 HasMany(s => s.Students).
                 WithOne(st => st.Staff).
                 OnDelete(DeleteBehavior.Restrict);
            //one room canhave many studnets
            //one studnet has one staa
            //one studnet one room
            //a rom cannot be dleetd if a stduent is allocate
            //a astaff cannot be deletd if a stident is allocated


        }
    
      
    }
}