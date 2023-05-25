using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagementDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("TaskManagementConnectionString")));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICheckListRepository, CheckListRepository>();

            services.AddScoped<ITasksRepository, TasksRepository>();
            return services;
        }
    }
}
