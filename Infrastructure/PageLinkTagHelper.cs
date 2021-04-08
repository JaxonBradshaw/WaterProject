using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterProject.Models.ViewModels;

namespace WaterProject.Infrastructure
{   //setting it up as a div tag
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        
        // stores anything that starts with page-url in the dictionary
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Overriding
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            //building navigation
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                //building a tag
                TagBuilder tag = new TagBuilder("a"); // tagBuilder = dynamically building html tags through C#

                PageUrlValues["pageNum"] = i;
                // attached the url values dictionary
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues); 

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                //appending tag that was built
                result.InnerHtml.AppendHtml(tag);
            }
            //finished product of my labors
            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}
