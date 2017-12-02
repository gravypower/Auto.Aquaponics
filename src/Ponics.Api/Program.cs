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
