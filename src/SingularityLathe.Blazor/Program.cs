using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SingularityLathe.RadLibs;
using SingularityLathe.Forge.AdventureForge;
using SingularityLathe.Forge.StellarForge.Services;
using SingularityLathe.Forge.StellarForge;
using Blazored.Modal;

namespace SingularityLathe.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSingleton<Random>();
            builder.Services.AddTransient(s => new RadLibConfiguration());
            builder.Services.AddTransient<RadLibService>();
            builder.Services.AddTransient<AdventureGeneratorService>();
            builder.Services.AddTransient<AnomalyGeneratorService>();
            builder.Services.AddTransient<PlanetBuilderService>();
            builder.Services.AddTransient<MoonBuilderService>();
            builder.Services.AddTransient<StellarForgeConfiguration>();
            builder.Services.AddTransient<StarSystemBuilderService>();

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
