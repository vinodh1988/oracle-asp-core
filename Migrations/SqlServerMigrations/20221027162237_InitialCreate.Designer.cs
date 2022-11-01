﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using OracleAPI.Models;

namespace OracleAPI.Migrations.SqlServerMigrations
{
    [DbContext(typeof(OracleDBContext))]
    [Migration("20221027162237_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("HR")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OracleAPI.Models.Person", b =>
                {
                    b.Property<short>("Sno")
                        .HasColumnType("NUMBER(5)")
                        .HasColumnName("sno");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("city");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR2(30)")
                        .HasColumnName("name");

                    b.HasKey("Sno")
                        .HasName("Pk_sno");

                    b.ToTable("PEOPLE", "HR");
                });
#pragma warning restore 612, 618
        }
    }
}
