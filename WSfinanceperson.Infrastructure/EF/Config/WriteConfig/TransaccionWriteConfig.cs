using Inventario.Domain.Models.Transacciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    public class TransaccionWriteConfig : IEntityTypeConfiguration<Transaccion>
    {
        public void Configure(EntityTypeBuilder<Transaccion> builder)
        {
            builder.ToTable("Transaccion");
            builder.HasKey(x => x.Id);

            var montotransConverter = new ValueConverter<MontoTransferencia, decimal>(
                montoTransValue => montoTransValue.Value,
                montoTrans => new MontoTransferencia(montoTrans)
            );

            builder.Property(x => x.Monto)
                .HasConversion(montotransConverter)
                .HasColumnName("monto");

            builder.Property(x => x.Descripcion).HasColumnName("descripcion");
            builder.HasOne(x => x.Cuenta);
            //builder.HasOne(typeof(Cuenta), "_cuenta");
            //builder.Property(x => x.Tipo).HasColumnName("tipo");
            var tipoConverter = new ValueConverter<Movimiento, string>(
                tipoEnumValue => tipoEnumValue.ToString(),
                tipo => (Movimiento)Enum.Parse(typeof(Movimiento), tipo)
            );

            builder.Property(x => x.Tipo)
                 .HasConversion(tipoConverter)
                 .HasColumnName("tipo")
                 .HasMaxLength(20)
                 .IsRequired();

            var estadoConverter = new ValueConverter<EstadoTransaccion, string>(
                estadoEnumValue => estadoEnumValue.ToString(),
                estado => (EstadoTransaccion)Enum.Parse(typeof(EstadoTransaccion), estado)
            );

            builder.Property(x => x.Estado)
                 .HasConversion(estadoConverter)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.HasOne(x => x.Categoria);
            //builder.HasOne(typeof(Categoria), "_categoria");

            var fechaTransConverter = new ValueConverter<FechaTransaccion, DateTime>(
                fechaTransValue => fechaTransValue.Value,
                fechatrans => new FechaTransaccion(fechatrans)
            );

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fechaRegistro")
                .HasConversion(fechaTransConverter)
                .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
            builder.Ignore(x => x.Categoria);
            //builder.Ignore(x => x.Cuenta);
        }
    }
}
