using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record MontoTransferencia
    {
        public decimal Value { get; init; }

        public MontoTransferencia(decimal value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("La cantidad no puede ser menor a 0");
            }
            Value = value;
        }
        public static implicit operator decimal(MontoTransferencia value)
        {
            return value.Value;
        }

        public static implicit operator MontoTransferencia(decimal value)
        {
            return new MontoTransferencia(value);
        }
    }
}
