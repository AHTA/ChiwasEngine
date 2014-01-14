using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiwasEngine.Helpers
{
    public static class BSButtonForExtensions
    {


        public static MvcHtmlString BSButtonFor(this HtmlHelper html, string Text)
        {
            return BSButtonFor(html, Text, ""); 
        }

        public static MvcHtmlString BSButtonFor(this HtmlHelper html, string Text, string OnClickAction)
        {
            return BSButtonFor(html, Text, OnClickAction, BSButtonClass.@default); 
        }

        public static MvcHtmlString BSButtonFor(this HtmlHelper html, string Text, string OnClickAction, BSButtonClass style)
        {
            return BSButtonFor(html, Text, OnClickAction, style, BSButtonType.button);
        }

        public static MvcHtmlString BSButtonFor(this HtmlHelper html, string Text, string OnClickAction, BSButtonClass style, BSButtonType button)
        {
            return BSButtonFor(html, Text, OnClickAction, style, button, BSButtonSize.def);
        }

        public static MvcHtmlString BSButtonFor(this HtmlHelper html, string Text, string OnClickAction, BSButtonClass style, BSButtonType button, BSButtonSize Size)
        {
            var label = new TagBuilder("button");

            label.MergeAttribute("type", button.ToString());
            label.AddCssClass("btn");
            label.AddCssClass("btn-" + style);
            label.AddCssClass("btn-" + Size);
            label.SetInnerText(Text);

            label.MergeAttribute("onClick", OnClickAction);

            return MvcHtmlString.Create(label.ToString());
        }

        public enum BSButtonType
        {
            button, 
            submit
        }

        public enum BSButtonClass
        {
            @default,
            primary,
            success,
            info,
            warning,
            danger,
            link
        }

        public enum BSButtonSize
        {
            def,
            lg, 
            sm,
            xs
        }
    }
}