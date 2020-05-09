using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace backlog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("https://localhost:44312").UseStartup<Startup>();
                });
    }
}
