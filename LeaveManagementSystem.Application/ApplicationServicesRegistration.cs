using LeaveManagementSystem.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LeaveManagementSystem.Application
{
    /// <summary>
    /// Abastacting the ApplicationSrvicesRegistration can call this mehtod and it would register any service that would defined into this service
    /// </summary>
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices (this IServiceCollection services)
        {
            //by adding it by Assembly.GetExecutingAssembly will just add any service that inherits the Profile class (from AutoMapper)
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
            //by adding typeof(MappingProfile) would require to add each service "MappingProfile" seperately
            //services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
