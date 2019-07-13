using Markdig;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using SingularityLathe.Web.Services;

namespace SingularityLathe.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MarkdownPipeline>(new MarkdownPipelineBuilder().UseAdvancedExtensions().Build());
            services.AddSingleton<AdventureGeneratorService>(new AdventureGeneratorService());
            services.AddSingleton<PlanetBuilderService>();
            services.AddSingleton<StarSystemGeneratorService>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
