using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.ValueObjects;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.EF.Config.ReadConfig
{
    public class CuentaReadConfig: IEntityTypeConfiguration<CuentaReadModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CuentaReadModel> builder)
        {
            builder.ToTable("Cuenta");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(x => x.PersonaId).HasColumnName("personaId").IsRequired();

            //builder.HasOne(x => x.Persona).WithMany().HasForeignKey(x => x.PersonaId);


            builder.Property(x => x.SaldoInicial)
                .HasColumnType("decimal")
                .HasColumnName("saldoInicial");

            //builder.HasMany(typeof(CategoriaReadModel), "_categoria");

            //builder.Ignore(x => x.Categorias);

        }
    }
}
