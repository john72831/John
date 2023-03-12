using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WireMock.Server;

namespace John.WireMock.Test
{
    public class IntegrationTestAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            var wiremockServer = WireMockServer.Start();

            builder.ConfigureAppConfiguration(webBuilder =>
            {
                webBuilder.AddInMemoryCollection(new KeyValuePair<string, string>[]
                {
                    new KeyValuePair<string, string>("Address", wiremockServer.Urls[0])
                }) ;
            });

            builder.ConfigureServices((collection) =>
            {
                collection.AddSingleton(wiremockServer);
            });
        }
    }
}
