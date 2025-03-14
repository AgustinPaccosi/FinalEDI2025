﻿// <auto-generated />
using FinalEDI2025.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalEDI2025.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalEDI2025.Entities.Plantas", b =>
                {
                    b.Property<int>("PlantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlantaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TipoDePlantaId")
                        .HasColumnType("int");

                    b.HasKey("PlantaId");

                    b.HasIndex("TipoDePlantaId");

                    b.ToTable("Plantas", (string)null);
                });

            modelBuilder.Entity("FinalEDI2025.Entities.TiposDePlantas", b =>
                {
                    b.Property<int>("TipoPlantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoPlantaId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TipoPlantaId");

                    b.HasIndex("Descripcion")
                        .IsUnique();

                    b.ToTable("TiposDePlantas", (string)null);
                });

            modelBuilder.Entity("FinalEDI2025.Entities.Plantas", b =>
                {
                    b.HasOne("FinalEDI2025.Entities.TiposDePlantas", "TipoDePlanta")
                        .WithMany("Plantas")
                        .HasForeignKey("TipoDePlantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoDePlanta");
                });

            modelBuilder.Entity("FinalEDI2025.Entities.TiposDePlantas", b =>
                {
                    b.Navigation("Plantas");
                });
#pragma warning restore 612, 618
        }
    }
}
