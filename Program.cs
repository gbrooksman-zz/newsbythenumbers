using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace newsbythenumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();

             Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.RollingFile("logs/log-{Date}.txt", fileSizeLimitBytes: 10000000, retainedFileCountLimit: 10)
                .CreateLogger();

             Log.Information("Application started");


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog() // <-- Add this lin
                .Build();
    }
}
