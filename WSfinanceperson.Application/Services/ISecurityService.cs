using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.Utils;

namespace WSfinanceperson.Application.Services
{
    public interface ISecurityService
    {
        Task<Result<string>> Login(string correo, string contrasena);
        Task<Result> Register(RegisterUserModel model);
    }
}
