using System.Linq;
using System.Threading.Tasks;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.ResourceManagement;
using SEO.OrchardCore.Models;
using SEO.OrchardCore.ViewModels;

namespace SEO.OrchardCore.Drivers
{
    public class SeoPartDisplayDriver : ContentPartDisplayDriver<SeoPart>
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;
        private readonly IResourceManager _resourceManager;

        public SeoPartDisplayDriver(IContentDefinitionManager contentDefinitionManager, IResourceManager resourceManager)
        {
            _contentDefinitionManager = contentDefinitionManager;
            _resourceManager = resourceManager;
        }

        public override async Task<IDisplayResult> DisplayAsync(SeoPart part, BuildPartDisplayContext context)
        {
            if (context.DisplayType == "Detail")
            {

                if (!string.IsNullOrWhiteSpace(part.Description))
                {
                    _resourceManager.RegisterMeta(new MetaEntry
                    {
                        Name = "description",
                        Content = part.Description
                    });
                }

                if (!string.IsNullOrWhiteSpace(part.Keywords))
                {
                    _resourceManager.RegisterMeta(new MetaEntry
                    {
                        Name = "keywords",
                        Content = part.Keywords
                    });
                }
            }

            return await base.DisplayAsync(part, context);
        }

        public override IDisplayResult Edit(SeoPart seoPart)
        {
            return Initialize<SeoPartViewModel>("SeoPart_Edit", model =>
            {
                model.Description = seoPart.Description;
                model.Keywords = seoPart.Keywords;
            }).Location("Parts#Seo:10");
        }

        public override async Task<IDisplayResult> UpdateAsync(SeoPart model, IUpdateModel updater)
        {
            await updater.TryUpdateModelAsync(model, Prefix, t => t.Description, t => t.Keywords);

            return Edit(model);
        }
    }
}
