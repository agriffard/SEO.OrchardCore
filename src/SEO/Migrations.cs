using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using System.Threading.Tasks;

namespace SEO.OrchardCore
{
    public class Migrations : DataMigration
    {
        IContentDefinitionManager _contentDefinitionManager;

        public Migrations(IContentDefinitionManager contentDefinitionManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
        }

        public async Task<int> CreateAsync()
        {
            await _contentDefinitionManager.AlterPartDefinitionAsync("SeoPart", builder => builder
                .Attachable()
                .WithDescription("Provides a SEO section for your content item."));

            return 1;
        }
    }
}