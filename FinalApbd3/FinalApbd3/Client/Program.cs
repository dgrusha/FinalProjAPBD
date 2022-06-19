using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FinalApbd3.Client.Repository;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace FinalApbd3.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("FinalApbd3.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQ5NDIxQDMyMzAyZTMxMmUzMFBaMnFDOHl1bTNSMW12VkEvbzFLODFUN2pXY2hESmI0RlBBN1NENFNITFk9");
            builder.Services.AddSyncfusionBlazor();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("FinalApbd3.ServerAPI"));
            

            builder.Services.AddApiAuthorization();

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPolygonRepository, PolygonRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
