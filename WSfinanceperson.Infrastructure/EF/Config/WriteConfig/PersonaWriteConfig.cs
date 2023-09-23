using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    internal class PersonaWriteConfig : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Correo).HasColumnName("correo").IsRequired();
            builder.Property(x => x.Contrasena).HasColumnName("contrasena").IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
        }
    }
}
