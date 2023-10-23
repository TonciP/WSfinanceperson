using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    [Table("Persona")]
    [Index(nameof(Correo), IsUnique = true)]
    public class PersonaReadModel
    {
        [Key]
        public Guid Id { get;  set; }
        [Required]
        [Column("correo")]
        public string Correo { get;  set; }
        [Required]
        [Column("contrasena")]
        public string Contrasena { get;  set; }
        //public List<CuentaReadModel> Cuentas { get;  set; }
        public List<CuentaReadModel> Cuentas { get; set; }
    }
}
