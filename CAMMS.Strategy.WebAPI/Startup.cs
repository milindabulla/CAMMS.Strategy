using CAMMS.Strategy.Application;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Strategy.Infrastructure;
using FluentValidation;
using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Scrutor;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;
using System.Reflection;

namespace CAMMS.Strategy.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            services.AddControllers();
            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnectionString"), name: "MS SQL Server Instance")
                .AddDiskStorageHealthCheck(s => s.AddDrive(Configuration["HealthConfiguration:DiskStorageDrive"], long.Parse(Configuration["HealthConfiguration:DiskStorageLimit"])), name: "Disk Storage")
                .AddProcessAllocatedMemoryHealthCheck(int.Parse(Configuration["HealthConfiguration:ProcessAllocatedMemoryLimit"]), name: "Process Allocated Memory")
                .AddPrivateMemoryHealthCheck(long.Parse(Configuration["HealthConfiguration:PrivateMemoryLimit"]), name: "Private Memory")
                .AddProcessHealthCheck("System", p => p.Length > 0, name: "System Process")
                .AddVirtualMemorySizeHealthCheck(long.Parse(Configuration["HealthConfiguration:VirtualMemoryLimit"]), name: "Virtual Memory")
                .AddRedis(Configuration["CacheSettings:Uri"], "Redis Cache URL")
                .AddUrlGroup(new Uri(Configuration["ElasticConfiguration:Uri"]), "Downstream - Elastic Search URL")
                .AddUrlGroup(new Uri(Configuration["KibanaConfiguration:Uri"]), "Downstream - Kibana URL");  

            services.AddHealthChecksUI(s =>
            {
                s.AddHealthCheckEndpoint("API Health System", Configuration["HealthConfiguration:HealthCheckUrl"]);
            }).AddInMemoryStorage();

            services.AddValidatorsFromAssembly(AppDomain.CurrentDomain.Load("CAMMS.Strategy.Application.Command"));
         
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddHttpContextAccessor();
            services.AddInfrastructure(Configuration);
            services.AddApplication(Configuration);
            services.AddInfrastructureAuthorizationBehavior(Configuration);
            services.AddInfrastructureLoggingBehaviour(Configuration);
            services.AddInfrastructureExceptionHandleBehaviour(Configuration);            
            services.AddApplicationValidationBehaviour(Configuration);
            services.AddInfrastructurePerformanceBehaviour(Configuration);
            services.AddInfrastructureCircuitBreakerBehaviour(Configuration);
            services.AddInfrastructureRetryBehaviour(Configuration);
            services.AddInfrastructureCachingBehaviour(Configuration);

            services.AddMediatR(AppDomain.CurrentDomain.Load("CAMMS.Strategy.Application.Query"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("CAMMS.Strategy.Application.Command"));

            services.Configure<CacheSettings>(Configuration.GetSection("CacheSettings"));

            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddSwaggerGen(
                            c =>
                            {
                                c.DocInclusionPredicate((docName, apiDesc) =>
                                {
                                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo))
                                    {
                                        return false;
                                    }

                                    System.Collections.Generic.IEnumerable<ApiVersion> versions = methodInfo.DeclaringType
                                        .GetCustomAttributes(true)
                                        .OfType<ApiVersionAttribute>()
                                        .SelectMany(a => a.Versions);

                                    return versions.Any(v => $"v{v.ToString()}" == docName);
                                });
                                c.SwaggerDoc(
                                    "v1.0",
                                    new OpenApiInfo
                                    {
                                        Title = "CAMMS API",
                                        Version = "v1.0"
                                    });
                                c.SwaggerDoc(
                                    "v2.0",
                                    new OpenApiInfo
                                    {
                                        Title = "CAMMS API",
                                        Version = "v2.0"
                                    });
                            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Company.Team.WebAPI v1"));
                app.UseSwaggerUI(
                  c => {
                      c.DefaultModelsExpandDepth(0);
                      c.SwaggerEndpoint($"/swagger/v1.0/swagger.json", "Camms.Strategy.WebAPI V1");
                      c.SwaggerEndpoint($"/swagger/v2.0/swagger.json", "Camms.Strategy.WebAPI V2");
                  }
                  );
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks(path: "/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(delegate (Options options)
            {
                options.UIPath = "/health";
            });
        }
    }
}
