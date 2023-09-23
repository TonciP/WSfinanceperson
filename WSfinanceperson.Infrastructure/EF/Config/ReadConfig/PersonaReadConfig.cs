using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.EF.Config.ReadConfig
{
    public class PersonaReadConfig : IEntityTypeConfiguration<PersonaReadModel>
    {
        public void Configure(EntityTypeBuilder<PersonaReadModel> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Correo)
                .HasColumnName("correo")
                .HasMaxLength(500);

            builder.Property(x => x.Contrasena)
                .HasColumnName("contrasena")
                .HasMaxLength(500);
        }
    }
}
