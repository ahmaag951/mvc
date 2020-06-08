using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace showing_popup_from_controller
{
    public static class LayoutHelpers
    {

        public static void UseFrontendLayout(this WebViewPage view, string title = "")
        {
            view.ViewBag.Title = title;
            if (view.Request.IsAjaxRequest())
            {
                view.Layout = null;
            }
            else
            {
                view.Layout = "~/Views/Shared/_Layout.cshtml";
            }
        }
        
        public static HtmlString RequireScript(this HtmlHelper html, string path, int priority = 1)
        {
            if (path.Contains("~"))
            {
                path = path.Replace("~", GetViewFolder(html));
            }
            if (html.ViewContext.HttpContext.Request.IsAjaxRequest())
            {
                return new HtmlString($"<script src=\"{path}\" type=\"text/javascript\"></script>\n");
            }
            else
            {
                var requiredScripts = HttpContext.Current.Items["RequiredScripts"] as List<ResourceInclude>;
                if (requiredScripts == null) HttpContext.Current.Items["RequiredScripts"] = requiredScripts = new List<ResourceInclude>();
                if (!requiredScripts.Any(i => i.Path == path)) requiredScripts.Add(new ResourceInclude() { Path = path, Priority = priority });
                return new HtmlString("");
            }
        }

        private static string GetViewFolder(HtmlHelper html)
        {
            var ViewPath = (html.ViewContext.View as System.Web.Mvc.RazorView)?.ViewPath ?? "";
            if (ViewPath.Contains("/"))
            {
                ViewPath = ViewPath.Substring(0, ViewPath.LastIndexOf("/"));
            }
            else
            {
                ViewPath = "";
            }

            ViewPath = ViewPath.Replace("~", "");
            return ViewPath;
        }

        public static HtmlString EmitRequiredScripts(this HtmlHelper html)
        {
            var requiredScripts = HttpContext.Current.Items["RequiredScripts"] as List<ResourceInclude>;
            if (requiredScripts == null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (var item in requiredScripts.OrderByDescending(i => i.Priority))
            {
                sb.AppendFormat("<script src=\"{0}\" type=\"text/javascript\"></script>\n", item.Path);
            }
            return new HtmlString(sb.ToString());
        }

        private class ResourceInclude
        {
            public string Path { get; set; }
            public int Priority { get; set; }
        }

        /// <summary>
        /// Could return null
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static PopupMessageResponse GetPopupMessageResponse(this WebViewPage self)
        {
            return self.TempData[PopupMessageResponse.TEMP_DATA_NAME] as PopupMessageResponse;
        }

        /// <summary>
        /// Could return empty HtmlString
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IHtmlString RenderPopupMessageResponse(this WebViewPage self)
        {
            var messageResponse = self.GetPopupMessageResponse();

            if (messageResponse == null)
            {
                return new HtmlString("");
            }
            else
            {
                return messageResponse.GetPopupMessageHtmlString();
            }
        }
        
    }
}