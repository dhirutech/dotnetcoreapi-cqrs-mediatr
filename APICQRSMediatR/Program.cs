using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using System;

namespace APICQRSMediatR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.EventCollector("http://localhost:8088/services/collector/raw", "5e863cc0-4ee3-40b1-8f1a-8b83ce47f83f")
            .CreateLogger();

            //Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Information()
            //        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //        .Enrich.FromLogContext()
            //        .WriteTo.Console()
            //        .CreateLogger();
            try
            {
                Log.Information("Getting host running...");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog();
    }
}
