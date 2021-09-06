using CAMMS.Strategy.Application.Interface;
using CAMMS.Strategy.Infrastructure.Behavior;
using CAMMS.Strategy.Infrastructure.Cache;
using CAMMS.Strategy.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CAMMS.Strategy.Infrastructure.Identity;
using CAMMS.Strategy.Application.DTO;

namespace CAMMS.Strategy.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(ICacheData), typeof(CacheData));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["CacheSettings:Uri"];
                options.InstanceName = configuration["CacheSettings:InstanceName"];
            });
            services.AddSingleton(typeof(IAuthorizer<AuthorizationResult>),typeof(RequestAuthorizer<AuthorizationResult>));
            services.AddScoped(typeof(IAuthenticator), typeof(JwtAuthenticator));
        }

        public static void AddInfrastructureLoggingBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
        }

        public static void AddInfrastructureExceptionHandleBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandleBehaviour<,>));
        }

        public static void AddInfrastructurePerformanceBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        }

        public static void AddInfrastructureCircuitBreakerBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CircuitBreakerBehaviour<,>));
        }

        public static void AddInfrastructureRetryBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryBehaviour<,>));
        }

        public static void AddInfrastructureCachingBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        }

        public static void AddInfrastructureAuthorizationBehavior(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));
        }
    }
}
