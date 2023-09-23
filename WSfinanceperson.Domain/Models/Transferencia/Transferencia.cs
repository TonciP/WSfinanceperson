using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.Models.Transferencia
{
    public class Transferencia: AggregateRoot<Guid>
    {
        public Guid Id { get; private set; }
        public DateTime FechaTransaferencia { get; private set; }
        public Guid CuentaOrigente { get; private set; }
        public Guid CuentaDestino { get; private set; }

        public Transferencia() { }

        public Transferencia(DateTime fechaTransaferencia, Guid cuentaOrigente, Guid cuentaDestino)
        {
            Id = new Guid();
            FechaTransaferencia = fechaTransaferencia;
            CuentaOrigente = cuentaOrigente;
            CuentaDestino = cuentaDestino;
        }
    }
}
