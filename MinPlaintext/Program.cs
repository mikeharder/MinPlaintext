using Benchmarks.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace MinKestrel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000);
                })
                .Configure(app => app.UseMiddleware<PlaintextMiddleware>().UseMiddleware<JsonMiddleware>())
                .Build()
                .Run();
        }
    }
}