using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using UrlSearch.Services;

namespace FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> 
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(IBrowserService));

                services.Remove(descriptor);

                services.AddTransient<IBrowserService, FakeBrowserService>();

                var sp = services.BuildServiceProvider();
            });
        }
    }
}
