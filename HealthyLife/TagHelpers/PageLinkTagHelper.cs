using HealthyLife.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HealthyLife.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            
            TagBuilder tag = new TagBuilder("ul");
            tag.AddCssClass("pagination");

            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            PageUrlValues["page"] = PageModel.PageNumber - 1;
            link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append("<");
            item.InnerHtml.AppendHtml(link);
            tag.InnerHtml.AppendHtml(item);

            TagBuilder firstItem = CreateTag(PageModel.FirstPage, urlHelper);
            tag.InnerHtml.AppendHtml(firstItem);
            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);
            
            if (PageModel.HasPreviousPage)
            {
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
                if (PageModel.PageNumber - PageModel.FirstPage == 1)
                {
                    prevItem.AddCssClass("hidden");
                }                
            }

            tag.InnerHtml.AppendHtml(currentItem);
            
            if (PageModel.PageNumber - PageModel.FirstPage == 0)
            {
                currentItem.AddCssClass("hidden");
                item.AddCssClass("disabled");
            }            

            if (PageModel.HasNextPage)
            {
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);                
                if (PageModel.TotalPages - PageModel.PageNumber < 2)
                {
                    nextItem.AddCssClass("hidden");
                }
            }
            TagBuilder scops = new TagBuilder("li");
            scops.InnerHtml.AppendHtml(" ");
            tag.InnerHtml.AppendHtml(scops);
            TagBuilder totalItem = CreateTag(PageModel.TotalPages, urlHelper);
            tag.InnerHtml.AppendHtml(totalItem);

            TagBuilder item2 = new TagBuilder("li");
            TagBuilder link2 = new TagBuilder("a");
            PageUrlValues["page"] = PageModel.PageNumber + 1;
            link2.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            item2.AddCssClass("page-item");
            link2.AddCssClass("page-link");
            link2.InnerHtml.Append(">");
            item2.InnerHtml.AppendHtml(link2);
            tag.InnerHtml.AppendHtml(item2);

            if (PageModel.TotalPages - PageModel.PageNumber == 0)
            {
                currentItem.AddCssClass("hidden");
                item2.AddCssClass("disabled");
            }
            if (PageModel.TotalPages == PageModel.FirstPage)
            {
                totalItem.AddCssClass("hidden");
            }
            output.Content.AppendHtml(tag);
        }

        TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
        {
            TagBuilder item = new TagBuilder("li");
            TagBuilder link = new TagBuilder("a");
            if (pageNumber == this.PageModel.PageNumber)
            {
                item.AddCssClass("active");
            }
            else
            {
                PageUrlValues["page"] = pageNumber;
                link.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            }
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
        }        
    }
}
