using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Domain.Models.Transaccion;

namespace WSfinanceperson.Domain.Events
{
    public record CuentaCreada : DomainEvent
    {
        public Guid CuentaId { get; set; }
        List<Categoria> Categorias { get; init; }
        public Guid PersonaId { get;  set; }
        public CuentaCreada(Guid cuentaId, List<Categoria> categoria, Guid personaId, DateTime occuredOn) : base(occuredOn)
        {
            CuentaId = cuentaId;
            Categorias = categoria;
            PersonaId = personaId;
        }
        
    }
}
