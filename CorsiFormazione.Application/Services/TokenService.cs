using CorsiFormazione.Application.Abstractions.Services;
using CorsiFormazione.Application.Models.Requests;
using CorsiFormazione.Application.Options;
using CorsiFormazione.Models.Context;
using CorsiFormazione.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CorsiFormazione.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthenticationOption _jwtAuthOption;
        private readonly UtenteService _utenteService;
        public TokenService(IOptions<JwtAuthenticationOption> jwtAuthOption, IUtenteService utenteService)
        {
            _jwtAuthOption = jwtAuthOption.Value;
            _utenteService = (UtenteService)utenteService;
        }

        public string CreateToken(CreateTokenRequest request)
        {
            Utente utente = _utenteService.PrendiUtente(request.email, request.password);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("Nome", utente.Nome));
            claims.Add(new Claim("Cognome", utente.Cognome));

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtAuthOption.Key));

            var credentials = new SigningCredentials(securityKey,
                 SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_jwtAuthOption.Issuer,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);       

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
