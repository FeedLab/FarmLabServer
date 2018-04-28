using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FarmLabService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://*:5000")
                .UseStartup<Startup>()
                .UseApplicationInsights()
         //       .UseAzureAppServices()
                .Build();
    }
}
