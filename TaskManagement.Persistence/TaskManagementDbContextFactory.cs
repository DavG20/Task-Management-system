using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaskManagement.Persistence
{
    public class TaskManagementDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
    {
        public TaskManagementDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory() + "/../TaskManagement.API")
                 .AddJsonFile("appsettings.json")
                 .Build();

            var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();
            var connectionString = configuration.GetConnectionString("TaskManagementConnectionString");

            builder.UseNpgsql(connectionString);

            return new TaskManagementDbContext(builder.Options);
        }
    }
}
