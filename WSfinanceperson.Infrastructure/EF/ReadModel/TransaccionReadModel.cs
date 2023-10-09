using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    public class TransaccionReadModel
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        //public Guid CuentaId { get; set; }
        //public Guid CategoriaId { get; set; }
        public CategoriaReadModel Categoria { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
    }
}
