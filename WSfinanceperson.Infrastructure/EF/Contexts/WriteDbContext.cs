using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WSfinanceperson.Infrastructure.EF.Contexts
{
    public class WriteDbContext
        : DbContext
    {
        //public virtual DbSet<Articulo> Articulo { set; get; }
        //public virtual DbSet<Transaccion> Transaccion { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var articuloConfig = new ArticuloWriteConfig();
            //modelBuilder.ApplyConfiguration(articuloConfig);

            //var transaccionConfig = new TransaccionWriteConfig();
            //modelBuilder.ApplyConfiguration<Transaccion>(transaccionConfig);
            //modelBuilder.ApplyConfiguration<DetalleTransaccion>(transaccionConfig);

            //modelBuilder.Ignore<DomainEvent>();
            //modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
