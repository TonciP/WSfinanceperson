using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transferencias;

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
            //builder.Property(x => x.PersonaId).HasColumnName("personaId").IsRequired();

            builder.HasOne(x => x.Persona);

            builder.Property(x => x.SaldoInicial).HasColumnName("saldoInicial");

            builder.HasMany(typeof(Categoria), "_categoria");
            //builder.HasMany(typeof(Transferencia), "_transferencia");
            //builder.HasMany(typeof(Transferencia), "_transferencia");

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
            builder.Ignore(x => x.Categorias);

        }

        //public void Configure(EntityTypeBuilder<Categoria> builder)
        //{
        //    builder.ToTable("Categorias");
        //    builder.HasKey(x => x.Id);

        //    builder.Property(x => x.Nombre).HasColumnName("name").IsRequired();

        //    builder.Ignore("_domainEvents");
        //    builder.Ignore(x => x.DomainEvents);

        //}
    }
}
