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
        //public Guid Id { get; private set; }
        //public DateTime FechaTransaferencia { get; private set; }
        //public Guid CuentaOrigente { get; private set; }
        //public Guid CuentaDestino { get; private set; }
        //public decimal Monto { get; private set; }
        //public Movimiento Tipo { get; private set; }
        //public EstadoTransaccion Estado { get; private set; }
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaTransaferencia)
                .HasColumnName("fechaTransferencia")
                .IsRequired();

            //builder.HasOne(x => x.CuentaOrigen);
            builder.HasOne(typeof(Cuenta), "cuentaorigen");
            //builder.HasOne(x => x.CuentaDestino);
            builder.HasOne(typeof(Cuenta), "cuentadestino");

            var montoConverter = new ValueConverter<MontoTransferencia, decimal>(
                               montoValue => montoValue.Value,
                                              monto => new MontoTransferencia(monto)
                                                         );

            builder.Property(x => x.Monto)
                .HasConversion(montoConverter)
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
            builder.Ignore(x => x.CuentaOrigen);
            builder.Ignore(x => x.CuentaDestino);
            //builder.Ignore(x => x.CuentaDestinoId);
            //builder.Ignore(x => x.CuentaOrigenId);

        }
    }
}
