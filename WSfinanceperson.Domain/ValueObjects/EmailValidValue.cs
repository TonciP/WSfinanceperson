using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WSfinanceperson.Domain.ValueObjects
{
    public record class EmailValidValue : ValueObject
    {
        public string Mail { get; }

        public EmailValidValue(string mail)
        {
            CheckRule(new StringNotNullOrEmptyRule(mail));
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (!regex.IsMatch(mail))
            {
                throw new BussinessRuleValidationException("Mail is Invalid");
            }
            Mail = mail;
        }

        public static implicit operator string(EmailValidValue value)
        {
            return value.Mail;
        }

        public static implicit operator EmailValidValue(string mail)
        {
            return new EmailValidValue(mail);
        }
    }
}
