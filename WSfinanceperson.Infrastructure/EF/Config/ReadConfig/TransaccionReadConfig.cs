using Inventario.Domain.Models.Transacciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.EF.Config.ReadConfig
{
    public class TransaccionReadConfig : IEntityTypeConfiguration<TransaccionReadModel>
    {
        public void Configure(EntityTypeBuilder<TransaccionReadModel> builder)
        {
            builder.ToTable("Transaccion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Monto).HasColumnName("monto");
            builder.Property(x => x.Descripcion).HasColumnName("descripcion");
            builder.HasOne(x => x.Cuenta);
            //builder.HasOne(typeof(Cuenta), "_cuenta");
            //builder.Property(x => x.Tipo).HasColumnName("tipo");


            builder.Property(x => x.Tipo)
                 .HasColumnName("tipo")
                 .HasMaxLength(20)
                 .IsRequired();


            builder.Property(x => x.Estado)
                 .HasColumnName("estado")
                 .HasMaxLength(20)
                 .IsRequired();

            builder.HasOne(x => x.Categoria);
            //builder.HasOne(typeof(Categoria), "_categoria");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fechaRegistro")
                .IsRequired();

            //builder.Ignore(x => x.Categoria);
        }
    }
}
