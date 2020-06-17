using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebWatchingAnime.Data.Context
{
    public class WebDbConrtextFactory : IDesignTimeDbContextFactory<WebDbContext>
    {
        public WebDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var conectionString = configuration.GetConnectionString("WebCoreDB");

            var optionsBuider = new DbContextOptionsBuilder<WebDbContext>();
            optionsBuider.UseSqlServer(conectionString).EnableSensitiveDataLogging();

            return new WebDbContext(optionsBuider.Options);
        }
    }
}
