using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template
{
    public class MyModel
    {
        [AllowHtml]
        public string Text { get; set; }
    }
}