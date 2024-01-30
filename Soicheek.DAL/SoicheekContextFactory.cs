using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Soicheek.DAL
{
    public class SoicheekContextFactory : IDesignTimeDbContextFactory<SoicheekContext>
    {
        public SoicheekContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SoicheekContext>();
            optionsBuilder.UseNpgsql(getConfiguration(args).GetConnectionString("SoicheekContext"));
            return new SoicheekContext(optionsBuilder.Options);
        }

        private IConfigurationRoot getConfiguration(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(getSoicheekFolder())
                .AddJsonFile(getConfigFile(args));
            return builder.Build();
        }

        private static string getSoicheekFolder()
        {
            string parentFolder = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName ?? throw new Exception("Nepodařilo se získat parent folder při načítání konfigurace");
            return Path.Join(Path.Join(parentFolder, "Soicheek"), "Soicheek");
        }

        private string getConfigFile(string[] args)
        {
            return isProduction(args) ? "appsettings.json" : "appsettings.Development.json";
        }

        private bool isProduction(string[] args)
        {
            if (args.Length == 2)
                if (args[0] == "--environment" && args[1] == "Production")
                    return true;
            return false;
        }
    }
}
