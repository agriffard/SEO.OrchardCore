using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrchardCore.ContentManagement;

namespace SEO.OrchardCore.ViewModels
{
    public class SeoPartViewModel
    {
        //public string PageTitle { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }

        //[BindNever]
        //public ContentItem ContentItem { get; set; }

        //[BindNever]
        //public SEOPart DisqusPart { get; set; }

        //[BindNever]
        //public DisqusPartSettings Settings { get; set; }
    }
}
