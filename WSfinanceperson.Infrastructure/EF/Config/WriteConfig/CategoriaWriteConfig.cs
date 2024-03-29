﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    public class CategoriaWriteConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasColumnName("nombre").IsRequired();
            builder.Property(x => x.CuentaId).HasColumnName("CuentaId").IsRequired();

            builder.HasOne<Cuenta>().WithMany().HasForeignKey("CuentaId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
