using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Blazored.LocalStorage;

namespace singularity_lathe.web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTelerikBlazor();
            services.AddBlazoredLocalStorage();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
