using Microsoft.EntityFrameworkCore;
using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Personas;
using WSfinanceperson.Infrastructure.EF.Config.WriteConfig;

namespace WSfinanceperson.Infrastructure.EF.Contexts
{
    public class WriteDbContext
        : DbContext
    {
        public virtual DbSet<Persona> Persona { set; get; }
        public virtual DbSet<Categoria> Categoria { set; get; }
        public virtual DbSet<Cuenta> Cuenta { set; get; }
        
        //public virtual DbSet<Transaccion> Transaccion { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var personaConfig = new PersonaWriteConfig();
            modelBuilder.ApplyConfiguration(personaConfig);

            var cuentaConfig = new CuentaWriteConfig();
            modelBuilder.ApplyConfiguration<Cuenta>(cuentaConfig);

            var categoriaConfig = new CategoriaWriteConfig();
            modelBuilder.ApplyConfiguration<Categoria>(categoriaConfig);

            modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
