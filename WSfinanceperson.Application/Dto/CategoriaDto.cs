using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.Dto
{
    public class CategoriaDto
    {
        public Guid Id { get; set; }
        public Guid CuentaId { get;  set; }
        public string Nombre { get;  set; }

        //public CategoriaDto( Guid cuentaId, string nombre)
        //{
        //    //Id = id;
        //    CuentaId = cuentaId;
        //    Nombre = nombre;
        //}
    }
}
