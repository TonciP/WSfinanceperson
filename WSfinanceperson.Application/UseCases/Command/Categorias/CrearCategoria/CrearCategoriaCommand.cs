using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.UseCases.Command.Categorias.CrearCategoria
{
    public class CrearCategoriaCommand: IRequest<Guid>
    {
        public Guid CuentaId { get;  set; }
        public string Nombre { get;  set; }
        public CrearCategoriaCommand() { }
        public CrearCategoriaCommand(Guid cuentaId, string nombre)
        {
            this.CuentaId = cuentaId;
            this.Nombre = nombre;
        }
    }
}
