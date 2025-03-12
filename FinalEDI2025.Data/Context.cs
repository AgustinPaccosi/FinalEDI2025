using FinalEDI2025.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEDI2025.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Plantas> Plantas { get; set; }
        public DbSet<TiposDePlantas> TiposDePlantas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TiposDePlantas>(entity =>
            {
                entity.ToTable("TiposDePlantas");
                entity.HasKey(e => e.TipoPlantaId);
                entity.HasIndex(t => t.Descripcion).IsUnique();
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Plantas>(entity =>
            {
                entity.ToTable("Plantas");
                entity.HasKey(e => e.PlantaId);
                entity.Property(e => e.Descripcion).IsRequired().HasMaxLength(100);
                entity.HasOne(s => s.TipoDePlanta).WithMany(b => b.Plantas).HasForeignKey(s => s.TipoDePlantaId);
            });


        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source =.;
        //                    Initial Catalog = ViveroEF;
        //                    Trusted_Connection = true;
        //                    TrustServerCertificate = true;");
        //}

    }
}
