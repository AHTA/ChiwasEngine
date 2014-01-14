using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ChiwasEngine.Models;
using System.Data.Entity;
using Microsoft.Data.Schema.SchemaModel;
using Microsoft.Data.Schema;

namespace ChiwasEngine.Models
{
    public class ChiwasEngineContext : System.Data.Entity.DbContext
    {
        public ChiwasEngineContext() : base("DefaultConnection") { }

        public DbSet<Pages> Pages { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Models.POCO.FacturaModels>()
        //                .HasMany(c => c.FacturaDetalles)
        //                .WithRequired(o => o.Factura)
        //                .HasForeignKey(o => o.FacturaDetalleId)
        //                .WillCascadeOnDelete(false);
        //    modelBuilder.Entity<Models.POCO.FacturaModels>()
        //        .HasOptional(f => f.FacturaDetalles)
        //        .WithRequired()
        //        .WillCascadeOnDelete();

        //}

    }
}