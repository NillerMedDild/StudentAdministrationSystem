using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace StudentAdministrationWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    var configuration = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
                    var httpsPort = configuration.GetValue("ASPNETCORE_HTTPS_PORT", 443); // takes from environment
                    var httpPort = configuration.GetValue("ASPNETCORE_HTTP_PORT", 80); // takes from environment
                    var certPassword = configuration.GetValue<string>("CertPassword"); // takes from environment
                    var certPath = configuration.GetValue<string>("CertPath"); //takes from environment

                    Console.WriteLine($"{nameof(httpsPort)}: {httpsPort}");
                    Console.WriteLine($"{nameof(certPassword)}: {certPassword}");
                    Console.WriteLine($"{nameof(certPath)}: {certPath}");

                    options.Listen(IPAddress.Any, httpsPort, listenOptions =>
                    {
                        listenOptions.UseHttps(certPath, certPassword);
                    });
                }).Build();
    }
}