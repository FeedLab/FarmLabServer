using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FarmLabService.Dal
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FarmLabContext>
    {
        public FarmLabContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<FarmLabContext>();
            var connectionString = configuration.GetConnectionString("MS_FarmLabConnectionString");
            builder.UseSqlServer(connectionString);
            return new FarmLabContext(builder.Options);
        }
    }
}
