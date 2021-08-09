using CAMMS.Strategy.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly AppSettings settings;

        public AuthorizationBehavior(IConfiguration configuration , IHttpContextAccessor httpContextAccessor
            , IOptions<AppSettings> settings)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
            this.settings = settings.Value;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var token = this.httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(token);
            }
            return await next();
        }

        private void AttachUserToContext(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(settings.Secret);
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

                configuration["ConnectionStrings:DefaultConnectionString"] = configuration.GetConnectionString("DefaultConnectionString").Replace("=master", "=" + database, StringComparison.OrdinalIgnoreCase);

            }
            catch
            {

            }
        }
    }
}
