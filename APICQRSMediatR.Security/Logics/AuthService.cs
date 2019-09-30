using APICQRSMediatR.Security.Interfaces;
using APICQRSMediatR.Security.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APICQRSMediatR.Security.Logics
{
    public class AuthService : IAuthService
    {
        LogedInUserModelData LogedInUser = new LogedInUserModelData();
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GetAccessToken(string userName, string password)
        {
            var user = LogedInUser._userList.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null) return null;

            var signingKey = Convert.FromBase64String(_config["Jwt:SigningSecret"]);
            var expiryDuration = int.Parse(_config["Jwt:ExpiryDuration"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("userid", user.UserId.ToString()),
                        new Claim("role", user.Role)
                    }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);

            return token;
        }
    }
}
