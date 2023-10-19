using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    [Table("Categoria")]
    public class CategoriaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        //[Column("CuentaId")]
        //[ForeignKey("CuentaId")]
        [Column("cuentaId")]
        [ForeignKey("cuentaId")]
        public Guid CuentaId { get; set; }
        public CuentaReadModel Cuenta { get; set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get;  set; }
    }
}
