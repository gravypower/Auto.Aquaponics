using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Ponics.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            var mongodbUri = @"mongodb://localhost:27017/Auto_Aquaponics";
            Environment.SetEnvironmentVariable("MONGODB_URI", mongodbUri);
            Environment.SetEnvironmentVariable("ALLOW_ORIGIN_WHITELIST", "http://localhost:4200,http://localhost:51272,http://192.168.1.128:51272,http://118.209.12.116:51272");
#endif
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
