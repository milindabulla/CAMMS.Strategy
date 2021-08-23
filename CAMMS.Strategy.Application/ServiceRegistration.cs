using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAMMS.Strategy.Application.ObjectMapping;

using MediatR;
using CAMMS.Strategy.Application.ObjectMapping.Common;

namespace CAMMS.Strategy.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(QuickUpdateStrategicRiskProfile));
            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(ParameterProfile));
            services.AddAutoMapper(typeof(SettingProfile));
        }

        public static void AddApplicationValidationBehaviour(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}
