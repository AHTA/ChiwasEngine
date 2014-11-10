using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ChiwasEngine.Models;
using System.Data.Entity;

namespace ChiwasEngine.Models
{
    public interface IChiwasEngineContext
    {
        DbSet<Pages> Pages { get; set; }
        DbSet<Categories> Categories { get; set; }
        DbSet<UserProfiles> UserProfiles { get; set; }
        DbSet<Setting> Settings { get; set; }
        int SaveChanges();
    }

    public class ChiwasEngineContext : DbContext, IChiwasEngineContext
    {
        public ChiwasEngineContext() : base("DefaultConnection") { }

        public DbSet<Pages> Pages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>()
                        .HasKey(x => new { x.Name, x.Type });

            modelBuilder.Entity<Setting>()
                        .Property(x => x.Value)
                        .IsOptional();

            base.OnModelCreating(modelBuilder);
        }

    }
}