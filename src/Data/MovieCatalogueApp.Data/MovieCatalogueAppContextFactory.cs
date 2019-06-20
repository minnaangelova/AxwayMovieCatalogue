using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
namespace MovieCatalogueApp.Data
{
    public class MovieCatalogueAppContextFactory : IDesignTimeDbContextFactory<MovieCatalogueAppContext>
    {

        public MovieCatalogueAppContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<MovieCatalogueAppContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection"); // Your Connection string - Minna or Ivaylo . 
                                                                                           // Could be set in appsettings.json file 

            builder.UseSqlServer(connectionString);

            // Stop client query evaluation
            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new MovieCatalogueAppContext(builder.Options);
        }
    }

}
