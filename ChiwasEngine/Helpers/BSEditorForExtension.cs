using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiwasEngine.Helpers
{
    public static class BSEditorForExtension
    {
        /// <summary>
        /// HTML Input de BootStrap
        /// </summary>
        /// <param name="html"></param>
        /// <param name="Type">Tipo de campo.</param>
        /// <param name="Id">Identificador del input.</param>
        /// <param name="PlaceHolder">Cpntenido del placeholder.</param>
        /// <returns></returns>
        public static MvcHtmlString BSEditorFor(this HtmlHelper html, BSEditorForExtension.BSInputTypes Type, string Id, string PlaceHolder)
        {
            var editor = new TagBuilder("input");
            editor.MergeAttribute("id", Id);
            editor.MergeAttribute("name", Id);
            editor.MergeAttribute("placeholder", PlaceHolder);
            editor.MergeAttribute("type", Type.ToString());
            editor.AddCssClass("form-control");

            return MvcHtmlString.Create(editor.ToString());
        }

        public static MvcHtmlString BSEditorFor(this HtmlHelper html, string value, BSEditorForExtension.BSInputTypes Type, string Id, string PlaceHolder)
        {
            var editor = new TagBuilder("input");
            editor.MergeAttribute("id", Id);
            editor.MergeAttribute("name", Id);
            editor.MergeAttribute("placeholder", PlaceHolder);
            editor.MergeAttribute("type", Type.ToString());

            editor.MergeAttribute("value", (String.IsNullOrWhiteSpace(value)) ? "" : value);

            editor.AddCssClass("form-control");

            return MvcHtmlString.Create(editor.ToString());
        }

        public enum BSInputTypes
        {
            text,
            password,
            datetime,
            datetime_local,
            date,
            month,
            time,
            week,
            number,
            email,
            url,
            search,
            tel,
            color,
        }
    }
}