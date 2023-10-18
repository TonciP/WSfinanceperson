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
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.Models.Transferencias;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    public class CuentaWriteConfig : 
        IEntityTypeConfiguration<Cuenta>
        //IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(x => x.PersonaId).HasColumnName("personaId").IsRequired();

            builder.HasOne<Persona>().WithMany().HasForeignKey("PersonaId");

            var saldoCuentaConverter = new ValueConverter<SaldoCuenta, decimal>(
                saldoCuentaEnumValue => saldoCuentaEnumValue.Value,
                saldoCuenta => new SaldoCuenta(saldoCuenta)
            );


            builder.Property(x => x.SaldoInicial)
                .HasConversion(saldoCuentaConverter)
                .HasColumnName("saldoInicial");

            //builder.HasMany(typeof(Categoria), "_categoria");
            //builder.HasMany(typeof(Transferencia), "_transferencia");
            //builder.HasMany(typeof(Transferencia), "_transferencia");

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
            //builder.Ignore(x => x.Categorias);

        }
    }
}
