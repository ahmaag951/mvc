using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        // now he doesn't know payId 
        // he only knows Id
        public string Index([Bind(Prefix = "Id")] int? payId)
        {
            if (payId == null)
            {
                payId = 0;
            }
            return payId.ToString();
        }

        // now he doesn't know payId even when you send it
        public string TestExclude([Bind(Exclude = "payId")] int? payId)
        {
            if (payId == null)
            {
                payId = 0;
            }
            return payId.ToString();
        }

        // This is like a white list
        // He will only pass id, name
        // and will not see id
        public string TestInclude([Bind(Include = "Address,Name")] Employee emp)
        {
            if (emp.Id == null)
            {
                emp.Id = 0;
            }
            return emp.Id.ToString();
        }

    }

    public class Employee{
        public int? Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
