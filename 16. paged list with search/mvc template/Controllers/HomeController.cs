using BusinessLogic;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        EmployeeProxy _EmployeeProxy = new EmployeeProxy();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadList(int? page, string term)
        {
            // from nuget add pagedlist.mvc and it will automatically install pagedlist
            // you have to write the using (using PagedList;) by your hand
            if (string.IsNullOrEmpty(term))
            {
                term = "";
            }
            IEnumerable<Employee> list = _EmployeeProxy.Items.Where(r => r.name.Contains(term));
            int pageSize = 2;
            IPagedList<Employee> pagedList = list.ToPagedList(page ?? 1, pageSize);
            return PartialView("_Index", pagedList);
        }

    }
}
