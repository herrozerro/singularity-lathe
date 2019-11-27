using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SingularityLathe.Blazor.Data;
using SingularityLathe.Forge.AdventureForge;
using SingularityLathe.Forge.StellarForge.Services;
using SingularityLathe.RadLibs;
using ElectronNET.API;
using Blazored.Modal;
using ElectronNET.API.Entities;

namespace SingularityLathe.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
            
            services.AddSingleton<Random>();
            services.AddTransient(s => new RadLibConfiguration());
            services.AddTransient<RadLibService>();
            services.AddTransient<AdventureGeneratorService>();
            services.AddTransient<AnomalyGeneratorService>();
            services.AddTransient<PlanetBuilderService>();
            services.AddTransient<MoonBuilderService>();
            services.AddTransient<StarSystemBuilderService>();

            services.AddBlazoredModal();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions(){
                Title = "Singularity Lathe",
                Width = 1600,
                Height = 800
            }));
        }
    }
}
