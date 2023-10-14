using Azure.Core;
using Microsoft.Extensions.Logging;
using Security.Infrastructure.Security;
using System.Text;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.Services;
using WSfinanceperson.Application.Utils;
using WSfinanceperson.Domain.Models.Personas;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;

namespace WSfinanceperson.Infrastructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly Persona _persona;
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<SecurityService> _logger;
        private string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public SecurityService(Persona persona, JwtOptions jwtOptions,
            ILogger<SecurityService> logger)
        {
            _persona = persona;
            _jwtOptions = jwtOptions;
            _logger = logger;
        }

        public Result<string> CreateHashPassword(string contrasena)
        {
            byte[] data =  Encoding.ASCII.GetBytes(contrasena);
            byte[] result = new SHA256Managed().ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return new Result<string>(sb.ToString(), true, "Hash creado");
        }

        public Result<string> CreateToken(string username)
        {
            var claims = new Claim[]
           {
            new Claim(ClaimTypes.Name, username),
                        new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
           };
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        SecurityAlgorithms.HmacSha256)
                        ),
                new JwtPayload(claims));
            string tokeSecurityHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return new Result<string>(tokeSecurityHandler, true, "User Succed");
        }

        //public Task<Result<string>> Login(string correo, string contrasena)
        //{
        //    //var user = _persona.
        //    throw new NotImplementedException();
        //}

        //public Task<Result> Register(RegisterUserModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
