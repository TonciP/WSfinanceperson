using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Infrastructure.EF.Config.ReadConfig;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.EF.Contexts
{
    public class ReadDbContext
        : DbContext
    {
        public virtual DbSet<PersonaReadModel> Persona { get; set; }
        public virtual DbSet<CategoriaReadModel> Categoria { set; get; }
        public virtual DbSet<CuentaReadModel> Cuenta { set; get; }
        public virtual DbSet<TransaccionReadModel> Transaccion { set; get; }
        public virtual DbSet<TransferenciaReadModel> Transferencia { set; get; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var personaConfig = new PersonaReadConfig();
            modelBuilder.ApplyConfiguration<PersonaReadModel>(personaConfig);

            var transaccionConfig = new TransaccionReadConfig();
            modelBuilder.ApplyConfiguration<TransaccionReadModel>(transaccionConfig);

            //var transaccionConfig = new TransaccionReadConfig();
            //modelBuilder.ApplyConfiguration<TransaccionReadModel>(transaccionConfig);
            //modelBuilder.ApplyConfiguration<DetalleTransaccionReadModel>(transaccionConfig);

            //modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
