using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    [Table("Transaccion")]
    public class TransaccionReadModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column("monto")]
        public decimal Monto { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Required]
        //[Column("CuentaId")]
        [Column("cuentaId")]
        public Guid CuentaId { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        [Required]
        //[Column("CategoriaId")]
        [Column("categoriaId")]
        public Guid CategoriaId { get; set; }
        public CategoriaReadModel Categoria { get; set; }

        [Required]
        [Column("fechaRegistro")]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }
        [Required]
        [Column("estado")]
        public string Estado { get; set; }
    }
}
