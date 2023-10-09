using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSfinanceperson.Application.Dto;
using WSfinanceperson.Application.UseCases.Auth.Personas;
using WSfinanceperson.Application.Utils;
using WSfinanceperson.Infrastructure.EF.Contexts;
using WSfinanceperson.Infrastructure.EF.ReadModel;

namespace WSfinanceperson.Infrastructure.UseCases.Query
{
    internal class LoginHandler : IRequestHandler<LoginUserDto, Result<string>>
    {
        private readonly DbSet<PersonaReadModel> persona;
        private string secret { get { return "WSFINANCE3T3N6PSJKWM"; } }

        public LoginHandler(ReadDbContext dbContext)
        {
            persona = dbContext.Persona;
        }

        public async Task<Result<string>> Handle(LoginUserDto request, CancellationToken cancellationToken)
        {
            var query = persona.AsNoTracking().AsQueryable();
            var result = await query.SingleOrDefaultAsync(x => x.Correo == request.Correo && x.Contrasena == request.Contrasena);

            
            if (result != null) 
            {
               var token = GenerateToken(result.Correo);
                return new Result<string>(token, true, "User Succed");
            }

            return new Result<string>(false, "Invalid User / Password");
        }

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
    }
}
