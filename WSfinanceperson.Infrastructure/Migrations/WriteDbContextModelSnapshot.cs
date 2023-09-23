﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WSfinanceperson.Infrastructure.EF.Contexts;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Cuentas.Cuenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<Guid>("PersonaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("SaldoInicial")
                        .HasColumnType("float")
                        .HasColumnName("saldoInicial");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Cuenta", (string)null);
                });

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Personas.Persona", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contrasena");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("correo");

                    b.HasKey("Id");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Transaccion.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CuentaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Cuentas.Cuenta", b =>
                {
                    b.HasOne("WSfinanceperson.Domain.Models.Personas.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Transaccion.Categoria", b =>
                {
                    b.HasOne("WSfinanceperson.Domain.Models.Cuentas.Cuenta", null)
                        .WithMany("_categoria")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WSfinanceperson.Domain.Models.Cuentas.Cuenta", b =>
                {
                    b.Navigation("_categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
