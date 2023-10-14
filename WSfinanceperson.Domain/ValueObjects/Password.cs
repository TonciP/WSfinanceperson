using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record class Password : ValueObject
    {
        public string Value { get; init; }

        public Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new BussinessRuleValidationException("La contraseña no puede ser vacia");
            }
            Value = value;
        }
        public static implicit operator string(Password value)
        {
            return value.Value;
        }

        public static implicit operator Password(string value)
        {
            return new Password(value);
        }
    }
}
