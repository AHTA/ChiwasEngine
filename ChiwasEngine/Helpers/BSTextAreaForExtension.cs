using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChiwasEngine.Helpers
{
    public static class BSTextAreaForExtension
    {
        public static MvcHtmlString BSTextAreaFor(this HtmlHelper html, string value, int row, string Id, string PlaceHolder)
        {
            var textArea = new TagBuilder("textarea");
            textArea.MergeAttribute("id", Id);
            textArea.MergeAttribute("name", Id);
            textArea.MergeAttribute("placeholder", PlaceHolder);
            textArea.MergeAttribute("type", row.ToString());
            textArea.AddCssClass("form-control");

            textArea.InnerHtml = (String.IsNullOrWhiteSpace(value)) ? "" : value;
            
            return MvcHtmlString.Create(textArea.ToString());
        }
    }
}