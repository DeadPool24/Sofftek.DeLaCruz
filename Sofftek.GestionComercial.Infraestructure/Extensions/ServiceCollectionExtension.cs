using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Sofftek.GestionComercial.Core.Core;
using Sofftek.GestionComercial.Core.Interface;
using Sofftek.GestionComercial.Core.Interface.IRepository;
using Sofftek.GestionComercial.Core.Interface.IService;
using Sofftek.GestionComercial.Core.Interfaces.IServices.Seguridad;
using Sofftek.GestionComercial.Core.Services;
using Sofftek.GestionComercial.Core.Services.Seguridad;
using Sofftek.GestionComercial.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sofftek.GestionComercial.Infraestructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration) { 
        
            services.AddScoped<IServiceVentas,ServiceVentas>();
            services.AddScoped<IRepositoryVentas, RepositoryVentas>();
            services.AddScoped<IServiceClientes, ServiceClientes>();
            services.AddScoped<IRepositoryClientes, RepositoryClientes>();
            services.AddScoped<IServiceArticulos, ServiceArticulos>();
            services.AddScoped<IRepositoryArticulos, RepositoryArticulos>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, Settings settings, string xmlFileName)
        {
            services.AddSwaggerGen(doc =>
            {
                var contact = new OpenApiContact() { Name = settings.ContactName, Url = new Uri(settings.ContactUrl) };
                doc.SwaggerDoc(settings.DocNameV1,
                                           new OpenApiInfo
                                           {
                                               Title = settings.DocInfoTitle,
                                               Version = settings.DocInfoVersion,
                                               Description = settings.DocInfoDescription,
                                               Contact = contact
                                           }
                                            );

                doc.CustomSchemaIds(i => i.FullName);
                doc.IncludeXmlComments(xmlFileName);
                doc.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }

    }
}
