using HealthyLife.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HealthyLife.TagHelpers
{
    public class SortTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public SortTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public string SortName { get; set; }
        public PageViewModel PageModel { get; set; }
        public string SortAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "sort-url-")]
        public Dictionary<string, object> SortUrlValues { get; set; } = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "li";
            
            TagBuilder link = new TagBuilder("a");
            link.Attributes["href"] = urlHelper.Action(SortAction, SortUrlValues);
            link.AddCssClass("dropdown-item sort-link");
            link.InnerHtml.AppendHtml(SortName);
            output.Content.AppendHtml(link);
        }        
    }
}
