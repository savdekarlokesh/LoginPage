using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace LoginApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(action =>
                {
                    action.ClearProviders();
                    //used here Microsoft.Extensions.Logging.EventLog for windows event logger
                    action.AddEventLog(settings =>
                        {
                            settings.SourceName = "LoginAPI";
                            settings.LogName = "SomeApi";
                        });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
