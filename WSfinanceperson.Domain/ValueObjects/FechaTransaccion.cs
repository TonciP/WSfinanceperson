using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record FechaTransaccion
    {
        public DateTime Value { get; init; }

        public FechaTransaccion(DateTime value)
        {
            if (!value.ToString("MM/dd/yyyy H:mm").Equals(DateTime.Now.ToString("MM/dd/yyyy H:mm")))
            {
                throw new BussinessRuleValidationException("La fecha no puede ser menor a la fecha actual");
            }
            Value = value;
        }
        public static implicit operator DateTime(FechaTransaccion fechaTransaccion) => fechaTransaccion.Value;
        public static implicit operator FechaTransaccion(DateTime fechaTransaccion) => new FechaTransaccion(fechaTransaccion);
    }
}
