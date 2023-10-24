using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record class Password : ValueObject
    {
        public string Value { get; init; }

        public Password(string value)
        {
            //letras de la A a la Z, mayusculas y minusculas
            Regex letras = new Regex(@"[a-zA-z]");
            //digitos del 0 al 9
            Regex numeros = new Regex(@"[0-9]");
            //cualquier caracter del conjunto
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            Boolean cumpleCriterios = false;

            //si no contiene las letras, regresa false
            if (!letras.IsMatch(value))
            {
                throw new BussinessRuleValidationException("La contraseña no contiene letras");
            }
            //si no contiene los numeros, regresa false
            if (!numeros.IsMatch(value))
            {
                throw new BussinessRuleValidationException("La contraseña no contiene numeros");
            }

            ////si no contiene los caracteres especiales, regresa false
            //if (!caracEsp.IsMatch(value))
            //{
            //    throw new BussinessRuleValidationException("La contraseña no contiene caracteres especiales");
            //}

            //si cumple con todo, regresa true
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
