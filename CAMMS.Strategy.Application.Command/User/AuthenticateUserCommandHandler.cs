using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using CAMMS.Strategy.Infrastructure.Identity;

namespace CAMMS.Strategy.Application.Command
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly JWTProvider jWTProvider;

        public AuthenticateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, JWTProvider jWTProvider)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
            this.jWTProvider = jWTProvider;
        }
        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            configuration["ConnectionStrings:DefaultConnectionString"] = configuration.GetConnectionString("DefaultConnectionString").Replace("=master", "=" + request.Database, StringComparison.OrdinalIgnoreCase);
            // Unicode because danb used it :/
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(request.Password);

            MD5CryptoServiceProvider md5csp = new MD5CryptoServiceProvider();
            byte[] md5ed = md5csp.ComputeHash(passwordBytes);
            Guid md5 = new Guid(md5ed);

            SHA1CryptoServiceProvider sha1csp = new SHA1CryptoServiceProvider();
            byte[] sha1 = sha1csp.ComputeHash(passwordBytes);

            SqlParameter[] parameterList =
            {
                new SqlParameter(){ParameterName = "USERNAME",Value=request.UserName },
                new SqlParameter(){ParameterName = "MD5PASSWORD",Value=md5 },
                new SqlParameter(){ParameterName = "SHA1PASSWORD",Value=sha1 }
            };
            string token = string.Empty; 
            var userId = await unitOfWork.GetRepository<Domain.User>().ExecuteScalarAsync(request.Database+ ".dbo.USERLOGIN", parameterList);
            if (userId != Guid.Empty)
            {
                Domain.User user = await unitOfWork.GetRepository<Domain.User>().GetByGuidAsync(userId);
                UserDto userDto = mapper.Map<UserDto>(user);
                token = jWTProvider.GenerateJwtToken(userDto, request.Database);
            }
            return token;
        }
    }
}
