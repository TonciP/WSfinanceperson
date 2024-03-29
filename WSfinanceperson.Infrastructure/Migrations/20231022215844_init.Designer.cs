﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WSfinanceperson.Infrastructure.EF.Contexts;

#nullable disable

namespace WSfinanceperson.Infrastructure.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    [Migration("20231022215844_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.CategoriaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CuentaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cuentaId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombre");

                    b.Property<Guid>("PersonaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("personaId");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("saldoInicial");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.PersonaReadModel", b =>
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
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("correo");

                    b.HasKey("Id");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.TransaccionReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("categoriaId");

                    b.Property<Guid>("CuentaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cuentaId");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaRegistro");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("monto");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("CuentaId");

                    b.ToTable("Transaccion");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.TransferenciaReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CuentaDestinoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cuentaDestinoId");

                    b.Property<Guid>("CuentaOrigenId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("cuentaOrigenId");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaTransferencia")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaTransferencia");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("monto");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tipo");

                    b.HasKey("Id");

                    b.HasIndex("CuentaDestinoId");

                    b.HasIndex("CuentaOrigenId");

                    b.ToTable("Transferencia");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.CategoriaReadModel", b =>
                {
                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", "Cuenta")
                        .WithMany("Categorias")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", b =>
                {
                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.PersonaReadModel", "Persona")
                        .WithMany("Cuentas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.TransaccionReadModel", b =>
                {
                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.CategoriaReadModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", "Cuenta")
                        .WithMany()
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.TransferenciaReadModel", b =>
                {
                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", "CuentaDestino")
                        .WithMany()
                        .HasForeignKey("CuentaDestinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", "CuentaOrigen")
                        .WithMany()
                        .HasForeignKey("CuentaOrigenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CuentaDestino");

                    b.Navigation("CuentaOrigen");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.CuentaReadModel", b =>
                {
                    b.Navigation("Categorias");
                });

            modelBuilder.Entity("WSfinanceperson.Infrastructure.EF.ReadModel.PersonaReadModel", b =>
                {
                    b.Navigation("Cuentas");
                });
#pragma warning restore 612, 618
        }
    }
}
