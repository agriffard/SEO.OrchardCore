using SEO.OrchardCore.Drivers;
using SEO.OrchardCore.Models;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;

namespace SEO.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<SeoPart>()
                .UseDisplayDriver<SeoPartDisplayDriver>();
            services.AddScoped<IDataMigration, Migrations>();
        }
    }
}