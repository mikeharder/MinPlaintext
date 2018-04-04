using Benchmarks.Data;
using Benchmarks.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Net;

namespace MinPlaintext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(
#if NETCOREAPP2_0 || NETCOREAPP2_1
                    options =>
                    {
                        options.Listen(IPAddress.Any, 5000);
                    }
#elif NETCOREAPP1_1
#else
#error Unknown target framework
#endif
                )
                .UseIISIntegration()
                .Configure(app => {
#if DEBUG
                    app.UseDeveloperExceptionPage();
#endif
                    app.UseMiddleware<PlaintextMiddleware>().UseMiddleware<JsonMiddleware>();

#if NETCOREAPP2_0 || NETCOREAPP2_1
                    app.UseMvc();
#elif NETCOREAPP1_1
#else
#error Unknown target framework
#endif
                })
#if NETCOREAPP2_0 || NETCOREAPP2_1
                .ConfigureServices(services =>
                {
                    services.AddMvcCore().AddControllersAsServices().AddViews().AddRazorViewEngine();

                    services.AddEntityFrameworkSqlServer();

                    var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
                    services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(config["ConnectionString"]));
                    services.AddScoped<EfDb>();
                })
#elif NETCOREAPP1_1
#else
#error Unknown target framework
#endif
                .Build()
                .Run();
        }
    }
}