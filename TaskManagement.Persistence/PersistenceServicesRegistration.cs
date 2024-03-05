using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.Repositories;

namespace TaskManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<TaskManagementDbContext>(options =>
                options
                .UseSqlServer(configuration.GetConnectionString("TaskManagementConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
