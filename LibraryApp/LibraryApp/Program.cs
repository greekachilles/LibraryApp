using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //   CreateWebHostBuilder(args).Build().Run();
            var host = BuildWebHost(args);
            InitializeDatabase(host);
            host.Run();

           
        }

        private static void InitializeDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    SeedData.InitAsync(services).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services
                        .GetRequiredService<ILogger<Program>>();

                    logger.LogError(ex, "Error occured seeding the DB");
                }
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
   //         WebHost.CreateDefaultBuilder(args)
   //             .UseStartup<Startup>();
  //  }
}
