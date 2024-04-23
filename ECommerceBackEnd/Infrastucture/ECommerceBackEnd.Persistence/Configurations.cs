using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackEnd.Persistence
{
    static class Configurations
    {
        public static string ConnectionString 
        {
            get
            {   //Presentation katmaninda olan API proyektinden json file-indan connection stringi goturmek ucundur.
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceBackEnd.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("PostgreSQL")!;
            }
        }
    }
}
