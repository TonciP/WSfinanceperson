using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSfinanceperson.Application.Dto
{
    public class RegisterUserModel
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public RegisterUserModel()
        {
            Correo = string.Empty;
            Contrasena = string.Empty;

        }
    }
}
