using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Destructurama;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace OnlineProdajaNamjestaja.Web
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .Build();
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            //Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            //var connectionString = @"Data Source=(local); Initial Catalog=EProdajaNamjestaja; Integrated Security=SSPI;";
            //var tableName = "Log";

            //var columnOption = new ColumnOptions();
            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Information()
            //    .MinimumLevel.Override("OnlineProdajaNamjestaja", LogEventLevel.Information)
            //    .WriteTo.MSSqlServer(connectionString, tableName, columnOptions: columnOption)
            //    .Destructure.UsingAttributes()
            //    .CreateLogger();


            //try
            //{
            //    Log.Information("Getting the motors running...");



            //    BuildWebHost(args).Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Host terminated unexpectedly");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseConfiguration(Configuration)
                .UseSerilog()
                .Build();
    }
}
