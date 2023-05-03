using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileStorage.EntityFrameworkCore
{
    public class FileStorageMigrationDbContextFactory : IDesignTimeDbContextFactory<FileStorageMigrationDbContext>
    {
        public FileStorageMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));
            var builder = new DbContextOptionsBuilder<FileStorageMigrationDbContext>()
                .UseMySql(configuration.GetConnectionString("FileStorage"),
                    serverVersion);

            return new FileStorageMigrationDbContext(builder.Options);
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
