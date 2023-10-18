using Inventario.Domain.Models.Transacciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Cuentas;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    [Table("Transferencia")]
    public class TransferenciaReadModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [Column("CuentaOrigenId")]
        public Guid CuentaOrigenId { get; set; }
        public CuentaReadModel CuentaOrigen { get; set; }
        [Required]
        [Column("CuentaDestinoId")]
        public Guid CuentaDestinoId { get; set; }
        public CuentaReadModel CuentaDestino { get; set; }

        [Required]
        [Column("monto")]
        public decimal Monto { get; set; }

        [Required]
        [Column("tipo")]
        public string Tipo { get; set; }
        [Required]
        [Column("estado")]
        public string Estado { get; set; }
        [Required]
        [Column("fechaTransferencia")]
        public DateTime FechaTransferencia { get; set; }
    }
}
