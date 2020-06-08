using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom_control_extension_methods
{
    public static class LabelExtensions
    {
        public static IHtmlString MyLabel(this HtmlHelper helper, string target, string text)
        {
            return new HtmlString(string.Format("<label for='{0}'>{1}</label>", target, text));
        }
    }
}