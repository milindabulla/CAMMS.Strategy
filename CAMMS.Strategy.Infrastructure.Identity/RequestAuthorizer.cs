using CAMMS.Strategy.Application;
using CAMMS.Strategy.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Identity
{
    public class RequestAuthorizer
    {
        private readonly IConfiguration configuration;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IHttpContextAccessor httpContextAccessor;

        public RequestAuthorizer(IConfiguration configuration, IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.appSettings = appSettings;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthorizationResult> AuthorizeAsync(IAuthorizedRequest authorizedRequest)
        {
            
            AuthorizationResult result = new AuthorizationResult();
            try
            {
                string token = authorizedRequest.Token.Split(" ").Last();
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                string database = jwtToken.Claims.First(x => x.Type == "Database").Value;
                Guid userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
                Guid systemPeriod = Guid.Parse(jwtToken.Claims.First(x => x.Type == "SystemPeriodId").Value);
                this.httpContextAccessor.HttpContext.Items.Add("Database", database);
                this.httpContextAccessor.HttpContext.Items.Add("UserId", userId);
                this.httpContextAccessor.HttpContext.Items.Add("SystemPeriodId", systemPeriod);

                this.configuration["ConnectionStrings:DefaultConnectionString"] = configuration.GetConnectionString("DefaultConnectionString").Replace("=master", "=" + database, StringComparison.OrdinalIgnoreCase);
                result = AuthorizationResult.Succeed();
            }
            catch(Exception e)
            {
                result = AuthorizationResult.Fail("Authorization Failed");
            }
            return result;
        }
    }
}
