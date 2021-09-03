using CAMMS.Strategy.Application;
using CAMMS.Strategy.Application.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Identity
{
    public class JwtAuthenticator : IAuthenticator
    {
        private readonly AppSettings appSettings;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        public JwtAuthenticator(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.appSettings = appSettings.Value;
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }
        public async Task<string> AuthenticateAsync(string database, string userName, string password)
        {
            string tokenString = string.Empty;

            configuration["ConnectionStrings:DefaultConnectionString"] = configuration.GetConnectionString("DefaultConnectionString").Replace("=master", "=" + database, StringComparison.OrdinalIgnoreCase);
            // Unicode because danb used it :/
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(password);

            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            byte[] md5ed = md5csp.ComputeHash(passwordBytes);
            Guid md5 = new Guid(md5ed);

            SHA1CryptoServiceProvider sha1csp = new SHA1CryptoServiceProvider();
            byte[] sha1 = sha1csp.ComputeHash(passwordBytes);
            
            SqlParameter[] parameterList =
            {
                new SqlParameter(){ParameterName = "USERNAME",Value=userName },
                new SqlParameter(){ParameterName = "MD5PASSWORD",Value=md5 },
                new SqlParameter(){ParameterName = "SHA1PASSWORD",Value=sha1 }
            };
            List<Domain.User> userlist = await unitOfWork.GetRepository<Domain.User>().ExecuteReaderAsync< Domain.User>(database+ ".dbo.UserLoginForAPI", parameterList);
            if (userlist != null && userlist.Count >0)
            {
                var user = userlist[0];
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                    new Claim("Database",database),
                    new Claim("SystemPeriodId",user.CurrentSystemPeriodId.HasValue? user.CurrentSystemPeriodId.ToString():Guid.Empty.ToString()),
                    new Claim("UserId",user.UserId.ToString())}),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenString = tokenHandler.WriteToken(token);
            }
            return tokenString;
        }
    }
}
