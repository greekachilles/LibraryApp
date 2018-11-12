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

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var serviceProvider = services.GetRequiredService<IServiceProvider>();
                    var config = services.GetRequiredService<IConfiguration>();
                    Seed.CreateRoles(serviceProvider, config).Wait();
                }
                catch (Exception exception)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "An error occured while creating roles");
                }
            }
            host.Run();
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
