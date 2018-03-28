using Benchmarks.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace MinPlaintext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new WebHostBuilder()
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
                .Configure(app => app.UseMiddleware<PlaintextMiddleware>().UseMiddleware<JsonMiddleware>())
                .Build()
                .Run();
        }
    }
}