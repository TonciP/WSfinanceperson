using Inventario.Domain.Models.Transacciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Domain.Models.Transferencias;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    public class TransferenciaWriteConfig : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);

            var fechaTransaccionConverter = new ValueConverter<FechaTransaccion, DateTime>(
                fechaTransaccionValue => fechaTransaccionValue.Value,
                fechaTransaccion => new FechaTransaccion(fechaTransaccion)
            );

            builder.Property(x => x.FechaTransaferencia)
                .HasConversion(fechaTransaccionConverter)
                .HasColumnName("fechaTransferencia")
                .IsRequired();

            //builder.HasOne(x => x.CuentaOrigen);
            //builder.HasOne(typeof(Cuenta), "cuentaorigen");
            //builder.HasOne(x => x.CuentaDestino);
            //builder.HasOne(typeof(Cuenta), "cuentadestino");

            var montoTransferenciaConverter = new ValueConverter<MontoTransferencia, decimal>(
                montoTransferenciaValue => montoTransferenciaValue.Value,
                montoTransferencia => new MontoTransferencia(montoTransferencia)
            );

            builder.Property(x => x.Monto)
                .HasConversion(montoTransferenciaConverter)
                .HasColumnName("monto");

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

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
            //builder.Ignore(x => x.CuentaOrigen);
            //builder.Ignore(x => x.CuentaDestino);
            //builder.Ignore(x => x.CuentaDestinoId);
            //builder.Ignore(x => x.CuentaOrigenId);

        }
    }
}
