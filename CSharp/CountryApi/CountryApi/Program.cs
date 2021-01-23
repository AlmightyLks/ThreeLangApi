using CountryApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace CountryApi
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateHostBuilder(args).Build().Run();


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton(services.BuildServiceProvider());
                    services.AddEntityFrameworkSqlite()
                        .AddDbContext<CountryContext>(option =>
                        {
                            #if DEBUG
                            option.EnableSensitiveDataLogging();
                            option.EnableDetailedErrors();
                            #endif
                        });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
