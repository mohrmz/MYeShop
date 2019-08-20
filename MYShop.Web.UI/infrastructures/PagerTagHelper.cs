using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MYShop.Domain.Entities;

namespace MYShop.Web.UI.infrastructures
{
    [HtmlTargetElement("nav", Attributes = "page-model")]
    public class PagerTagHelper:TagHelper
    {

        private IUrlHelperFactory urlHelperFactory;
        public PagerTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingData PageModel { get; set; }
        public string PageAction { get; set; }
        public string PageContoller { get; set; }
        public string PageCategory { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("ul");

            result.Attributes["class"] = "pagination";
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder litag = new TagBuilder("li");
                TagBuilder tag = new TagBuilder("a");
                if (string.IsNullOrWhiteSpace(PageCategory))
                {
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageContoller, new { page = i });
                }
                else
                {
                    tag.Attributes["href"] = urlHelper.Action(PageAction, PageContoller, new { page = i, category = PageCategory });
                }
                    tag.InnerHtml.Append(i.ToString());
                litag.InnerHtml.AppendHtml(tag);
                result.InnerHtml.AppendHtml(litag);
            }
            output.Content.AppendHtml(result);
        }
    }
}
