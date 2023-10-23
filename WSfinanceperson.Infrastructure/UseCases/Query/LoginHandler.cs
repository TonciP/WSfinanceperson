using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WSfinanceperson.Application.UseCases.Auth.Personas;
using WSfinanceperson.Application.Utils;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;
using System.Security.Cryptography;
using Azure.Core;

namespace WSfinanceperson.Infrastructure.UseCases.Query
{
    internal class LoginHandler : IRequestHandler<LoginUserDto, Result<string>>
    {
        private readonly DbSet<PersonaReadModel> _persona;
        private string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public LoginHandler(ReadDbContext dbContext)
        {
            _persona = dbContext.Persona;
        }

        public async Task<Result<string>> Handle(LoginUserDto request, CancellationToken cancellationToken)
        {
            //var query = persona.AsNoTracking().AsQueryable();

            string hash = hashSecutiry(request.Contrasena);

            var result = await _persona.SingleOrDefaultAsync(x => x.Correo == request.Correo && x.Contrasena == hash);

            
            if (result != null) 
            {
                var token = GenerateToken(result.Id.ToString());
                return new Result<string>(token, true, "User Succed");
                //return await _securityService.CreateToken(result.Id.ToString());
            }

            return new Result<string>(false, "Invalid User / Password");
        }

        #region generation token
        private string GenerateToken(string username)
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
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        #endregion generation token

        private string hashSecutiry(string contrasena)
        {
            #region hash password
            byte[] data = Encoding.ASCII.GetBytes(contrasena);
            byte[] resultbyte = new SHA256Managed().ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultbyte.Length; i++)
            {

                // Convertimos los valores en hexadecimal
                // cuando tiene una cifra hay que rellenarlo con cero
                // para que siempre ocupen dos dígitos.
                if (resultbyte[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(resultbyte[i].ToString("x"));
            }

            #endregion hash password

            return sb.ToString();
        }
    }
}
