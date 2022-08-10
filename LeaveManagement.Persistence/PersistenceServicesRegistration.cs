using LeaveManagement.Application.Persisence.Contracts;
using LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagementDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("LeaveManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped <ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            return services;
        }
    }
}
