using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace PracticeManagement.API.Database
{
    public class EfContextFactory
         : IDesignTimeDbContextFactory<EfContext>
    {
        static string? connectionString = null;
        static EfContextFactory()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();

            connectionString = config["ConnectionStrings:PracticeManagement_DB"];
        }
        public EfContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EfContext(optionsBuilder.Options);
        }
    }
}
