using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Echic.Common
{
    public class ConfigBuilder
    {
        public static IConfiguration Configuration { get; set; }

        public static IConfigurationBuilder ConfBuilder { get; set; }

        static ConfigBuilder()
        {
            ConfBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory());

            var appSettingUri = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            if (File.Exists(appSettingUri))
            {
                ConfBuilder.AddJsonFile("appsettings.json", true, true);
            }

            Configuration = ConfBuilder.Build();
        }
    }
}
