using WSfinanceperson.Domain.Models.Transacciones;
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
using WSfinanceperson.Domain.ValueObjects;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.EF.Config.ReadConfig
{
    public class TransferenciaReadConfig : IEntityTypeConfiguration<TransferenciaReadModel>
    {
        public void Configure(EntityTypeBuilder<TransferenciaReadModel> builder)
        {
            builder.ToTable("Transferencia");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaTransferencia)
                .HasColumnName("fechaTransferencia")
                .IsRequired();

            builder.HasOne(x => x.CuentaOrigen);
            //builder.HasOne(typeof(CuentaReadModel), "CuentaOrigen");
            builder.HasOne(x => x.CuentaDestino);
            //builder.HasOne(typeof(CuentaReadModel), "CuentaDestino");

            builder.Property(x => x.Monto)
                .HasColumnType("decimal")
                .HasColumnName("monto");


            builder.Property(x => x.Tipo)
                 .HasColumnName("tipo")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.Property(x => x.Estado)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            //builder.Ignore(x => x.CuentaOrigen);
            //builder.Ignore(x => x.CuentaDestino);
            //builder.Ignore(x => x.CuentaDestinoId);
            //builder.Ignore(x => x.CuentaOrigenId);
        }
    }
}
