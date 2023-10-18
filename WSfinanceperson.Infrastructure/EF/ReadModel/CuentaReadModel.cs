using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    [Table("Cuenta")]
    public class CuentaReadModel
    {
        [Key]
        public Guid Id { get;  set; }
        [Required]
        [Column("nombre")]
        public string Nombre { get;  set; }
        [Required]
        [Column("saldoInicial")]
        public decimal SaldoInicial { get;  set; }
        [Column("PersonaId")]
        [ForeignKey("PersonaId")]
        public Guid PersonaId { get;  set; }
        public PersonaReadModel Persona { get; set; }

        public List<CategoriaReadModel> Categorias { get; set; }
    }
}
