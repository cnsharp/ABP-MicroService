using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BaseService.EntityFrameworkCore
{
    public class BaseServiceMigrationDbContextFactory : IDesignTimeDbContextFactory<BaseServiceMigrationDbContext>
    {
        public BaseServiceMigrationDbContext CreateDbContext(string[] args)
        {
            BaseEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));
            var builder = new DbContextOptionsBuilder<BaseServiceMigrationDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"),
                    serverVersion);

            return new BaseServiceMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
