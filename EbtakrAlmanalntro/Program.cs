using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EbtakrAlmanalntro.Data;
using EbtakrAlmanalntro.Data.TableDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbtakrAlmanalntro
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //  CreateHostBuilder(args).Build().Run();

            ////Read Configuration from appSettings
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            ////  Initialize Logger
            //  Log.Logger = new LoggerConfiguration()
            //      .ReadFrom.Configuration(config)
            //      .CreateLogger();


            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationDbUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    var _Context = services.GetRequiredService<ApplicationDbContext>();

                    await EbtakrAlmanalntro.Seeds.DefaultRoles.SeedAsync(userManager, roleManager);
                    await EbtakrAlmanalntro.Seeds.DefaultBasicUser.SeedAsync(userManager, roleManager);
                    await EbtakrAlmanalntro.Seeds.DefaultSettings.SeedAsync(_Context);
                    await EbtakrAlmanalntro.Seeds.DefaultSocialMedia.SeedAsync(_Context);
                }
                catch (Exception)
                {

                }
            }
            try
            {
                //Log.Information("Application Starting.");
                host.Run();
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "The Application failed to start.");
            }
            finally
            {
                //Log.CloseAndFlush();
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
