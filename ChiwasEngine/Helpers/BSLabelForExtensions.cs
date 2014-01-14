using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiwasEngine.Helpers
{
    public static class BSLabelForExtensions
    {
        public static MvcHtmlString BSLabelFor(this HtmlHelper html, string Id, string Text)
        {
            return BSLabelFor(html, Id, Text, "col-lg-2");
        }

        public static MvcHtmlString BSLabelFor(this HtmlHelper html, string Id, string Text, string CssClass)
        {
            var label = new TagBuilder("label");

            label.MergeAttribute("id", Id);
            label.AddCssClass(CssClass);
            label.AddCssClass("control-label");
            label.SetInnerText(Text);

            return MvcHtmlString.Create(label.ToString());
        }
    }
}