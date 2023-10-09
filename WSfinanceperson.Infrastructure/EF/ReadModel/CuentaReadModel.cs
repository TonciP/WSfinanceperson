using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Categorias;
using WSfinanceperson.Domain.Models.Personas;

namespace WSfinanceperson.Infrastructure.EF.ReadModel
{
    public class CuentaReadModel
    {
        public Guid Id { get;  set; }
        public string Nombre { get;  set; }
        public decimal SaldoInicial { get;  set; }
        public Guid PersonaId { get;  set; }
        public PersonaReadModel _persona;



        //public List<CategoriaReadModel> _categoria;

    }
}
