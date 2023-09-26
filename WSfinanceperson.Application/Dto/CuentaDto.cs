using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Application.Dto
{
    public class CuentaDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public double SaldoInicial { get; set; }
        public Persona Persona{ get; set; }
        public List<Categoria> Categorias { get; set; }  
    }
}
