using BlogSystemAPI.Data;
using BlogSystemAPI.Models;
using BlogSystemAPI.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSystemAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            CreateDatabase(host);
            host.Run();
        }
        private static void CreateDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var appDBContext = services.GetRequiredService<BlogDBContext>();

                    var settings = services.GetRequiredService<AppSettings>();

                    if (settings.Migrate)
                    {
                        appDBContext.Database.Migrate();

                        appDBContext.Users.Add(new Models.Database.User()
                        {
                            Name = "Vural",
                            Surname = "Vardarelli",
                            Username = "kaizen",
                            Password = Hashing.Encrypt("1234",settings.PasswordHashSecret)
                        });

                        appDBContext.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred while creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
