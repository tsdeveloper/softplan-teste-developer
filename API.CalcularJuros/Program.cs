using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace API.CalcularJuros
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            BuildWebHost(args)
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args).Build();
            var enviroment = config["environment"] ?? "Development";

            return WebHost.CreateDefaultBuilder(args)
                .UseEnvironment(enviroment)
                .UseStartup<Startup>()
                .UseKestrel ()
                .UseContentRoot (Directory.GetCurrentDirectory ())
                .Build();
        }
    }
}
