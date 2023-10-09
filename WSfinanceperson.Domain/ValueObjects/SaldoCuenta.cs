using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record SaldoCuenta
    {
        public decimal Value { get; init; }

        public SaldoCuenta(decimal value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("La cantidad no puede ser menor a 0");
            }
            Value = value;
        }

        public static implicit operator decimal(SaldoCuenta value)
        {
            return value.Value;
        }

        public static implicit operator SaldoCuenta(decimal value)
        {
            return new SaldoCuenta(value);
        }

    }
}
