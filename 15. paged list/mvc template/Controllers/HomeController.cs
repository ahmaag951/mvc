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
        public ActionResult Index(int? page)
        {
            // from nuget add pagedlist.mvc and it will automatically install pagedlist
            // you have to write the using (using PagedList;) by your hand
            IEnumerable<Employee> list = _EmployeeProxy.Items.ToList();
            int pageNumber = 1;
            int pageSize = 10;
            IPagedList<Employee> pagedList = list.ToPagedList(page ?? 1, pageSize);
            return View(pagedList);
        }

    }
}
