using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TK_Project.Application.Interfaces.Auth;
using TK_Project.Application.ViewModel;

namespace TK_Project.Persistance.Auth
{
    public class TokenService : ITokenService
    {
        readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<GenerateTokenResponse> GenerateToken(GenerateTokenRequest request)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name,request.Username));
            foreach (var item in request.RoleName)
            {
                claims.Add(new Claim(ClaimTypes.Role,item));
            }

            var claimArray = claims.ToArray();

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]));
            var dateTimeNow = DateTime.Now;
            var expiresDate = dateTimeNow.AddMinutes(30);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _configuration["AppSettings:ValidIssuer"],
                audience: _configuration["AppSettings:ValidAudience"],
                claims:claimArray,
                notBefore:dateTimeNow,
                expires:expiresDate,
                signingCredentials:new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha256)
                );


            return Task.FromResult(new GenerateTokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                TokenExpireDate =expiresDate
            });
        }
    }
}
