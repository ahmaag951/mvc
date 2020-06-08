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
        public enum ColumnsOrder { name, email, age }
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult LoadList(int? page, string term)
        //{
        //    // from nuget add pagedlist.mvc and it will automatically install pagedlist
        //    // you have to write the using (using PagedList;) by your hand
        //    if (string.IsNullOrEmpty(term))
        //    {
        //        term = "";
        //    }

        //    IEnumerable<Employee> list = _EmployeeProxy.Items.Where(r => r.name.Contains(term));

        //    int pageSize = 2;
        //    IPagedList<Employee> pagedList = list.ToPagedList(page ?? 1, pageSize);
        //    return PartialView("_Index", pagedList);
        //}

        public ActionResult LoadList(int? page, string term, int? sortByColumnIndex)
        {
            // from nuget add pagedlist.mvc and it will automatically install pagedlist
            // you have to write the using (using PagedList;) by your hand
            if (string.IsNullOrEmpty(term))
            {
                term = "";
            }

            string debug = (sortByColumnIndex == null ? "" : Enum.GetName(typeof(ColumnsOrder), sortByColumnIndex));

            IEnumerable<Employee> list = (sortByColumnIndex == null ? _EmployeeProxy.Items.Where(r => r.name.Contains(term)) : _EmployeeProxy.Items.Where(r => r.name.Contains(term)).AsQueryable().OrderBy(debug + "  desc")); // for descing order


            int pageSize = 10;
            IPagedList<Employee> pagedList = list.ToPagedList(page ?? 1, pageSize);
            return PartialView("_Index", pagedList);
        }
    }
}
