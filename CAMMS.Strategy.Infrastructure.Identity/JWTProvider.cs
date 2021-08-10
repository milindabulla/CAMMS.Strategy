using CAMMS.Strategy.Application;
using CAMMS.Strategy.Application.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CAMMS.Strategy.Infrastructure.Identity
{
    public class JWTProvider
    {
        private readonly AppSettings appSettings;

        public JWTProvider(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        public string GenerateJwtToken(UserDto user, string databaseName)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("Database",databaseName),
                    new Claim("SystemPeriodId",user.CurrentSystemPeriodId.HasValue? user.CurrentSystemPeriodId.ToString():Guid.Empty.ToString()),
                    new Claim("UserId",user.UserId.ToString())}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
