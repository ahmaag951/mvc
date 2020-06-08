using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        EmployeeProxy _EmployeeProxy = new EmployeeProxy();

        public ActionResult Index()
        {
            
            return View();
        }


        public ActionResult loadData()
        {
            // Get Parameters
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            var sortColumn =
                Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() +
                                       "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int take = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            // search
            var name = Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
            // Get list
            var list = _EmployeeProxy.Items.AsQueryable().OrderBy(sortColumn + " " + sortColumnDir).Skip(skip).Take(take);


            //var v = allQuestions.Distinct().ToList();

            int totalRecords = _EmployeeProxy.Items.Count();
            var listSerialized = new
            {
                draw = draw,
                recordsFiltered = totalRecords,
                recordsTotal = totalRecords,

                data = list.Select(model => new
                {
                    model.email,
                    model.age,


                })
            };



            var test = Json(
                listSerialized,
                JsonRequestBehavior.AllowGet);
            return test;
        }

    }
}
