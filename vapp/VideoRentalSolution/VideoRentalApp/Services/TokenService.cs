﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VideoRentalApp.Interfaces;
using VideoRentalApp.Models.DTOs;

namespace VideoRentalApp.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration)
        {
            var secretKey = configuration["SecretKey"].ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        }
        public string GetToken(UserDTO user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.Username),
                new Claim("role",user.Role)
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);

        }

    }
}