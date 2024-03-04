using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence
{
    public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                            //.SetBasePath(Directory.GetCurrentDirectory())
                            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "TaskManagement.API"))
                            .AddJsonFile("appsettings.json")
                            .Build();

            var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();
            var connectionString = configuration.GetConnectionString("TaskManagementConnectionString");

            builder.UseSqlServer(connectionString);

            return new TaskManagementDbContext(builder.Options);
        }
    }
}
