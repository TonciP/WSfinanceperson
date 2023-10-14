using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Domain.ValueObjects;

namespace WSfinanceperson.Infrastructure.EF.Config.WriteConfig
{
    internal class PersonaWriteConfig : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona");
            builder.HasKey(x => x.Id);

            var emailConverter = new ValueConverter<EmailValidValue, string>(
                emailValue => emailValue.Mail,
                email => new EmailValidValue(email)
            );

            builder.Property(x => x.Correo)
                .HasConversion(emailConverter)
                .HasColumnName("correo")
                .IsRequired();

            var passwordConverter = new ValueConverter<Password, string>(
                passwordValue => passwordValue.Value,
                password => new Password(password)
            );

            builder.Property(x => x.Contrasena)
                .HasConversion(passwordConverter)
                .HasColumnName("contrasena")
                .IsRequired();

            builder.Ignore("_domainEvents");
            builder.Ignore(builder => builder.DomainEvents);
        }
    }
}
