using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using System.Web;
using System.Web.Mvc;
//using Company_DAL.;
using Company_BLL;
using Company_UI.Models;
using Company_UI.Filters;
using Company_UI.Helpers;
using System.Linq.Dynamic;

namespace Company_UI.Controllers
{
    public class HomeController : Controller
    {
        Employee_Proxy _Employee_Proxy = new Employee_Proxy();        

        public ActionResult Index(int? id)
        {            
            if (id != null)
            {
                Company_DAL.Employee employee = _Employee_Proxy.GetById((int)id);
                //ViewBag.Employee = employee;
                ViewData["Employee"] = employee;
                //return View(AutoMapper.Mapper.Map<Employee, EmployeeModel>(employee));
                return View(employee);
            }
            //return View(_Employee_Proxy.GetAllEmployeesWithDeleted());
            return View(new Company_DAL.Employee());
            
        }        

        //[HttpGet]
        //public JsonResult Details()
        //{
        //    int id = 1;
        //    Employee employee = _Employee_Proxy.GetById((int)id);
        //    ViewData["Employee"] = Company_DAL.employee;
        //    var vvv = Json(employee);
        //    IEnumerable<Employee> list = _Employee_Proxy.GetAllEmployees();
        //    return Json(list, JsonRequestBehavior.AllowGet);            
            
        //}

        [HttpPost]
        public ActionResult loadData()
        {
            // Get Parameters


            // get start (paging start index) and length (page size for pagging)
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            // get sort columns value
            var sortColumn =
                Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() +
                                       "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int totalRecords = 0;

            using (Company_DAL.CompanyEntities dc = new Company_DAL.CompanyEntities())
            {
                var v = (from a in dc.Employees select a);
                // sorting
                
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    v = v.OrderBy( sortColumn + " " + sortColumnDir);
                }
                totalRecords = v.Count();
                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(
                    new {draw = draw, recordsFiltered = totalRecords, recordsTotal = totalRecords, data = data},
                    JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult CreateWithAjax(string name, string email, int age)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Employee employee = new Employee { name = name, email = email, age = age };
        //        _Employee_Proxy.Add(employee);
        //        return Json(employee);                
        //    }
        //    return Json(new Employee());                
        //}

        //[HttpPost]
        //public ActionResult UpdateFromAjax(int id, string name, string email, int age)
        //{            
        //    if (ModelState.IsValid)
        //    {      
        //        Employee employee = new Employee{ id = id, name = name, email = email, age = age};
        //        _Employee_Proxy.Update(employee);                
        //    }
        //    return RedirectToAction("Index");
        //}



        //[HttpPost]
        //public ActionResult DeleteFromAjax(int id)
        //{
        //    Employee employee = _Employee_Proxy.GetById(id);
        //    if (employee.isDeleted)
        //    {
        //        employee.isDeleted = false;
        //    }
        //    else
        //    {
        //        employee.isDeleted = true;
        //    }
        //    _Employee_Proxy.Update(Company_DAL.employee);
        //    return RedirectToAction("Index");
        //}
        
        protected override void Dispose(bool disposing)
        {
            Company_DAL.CompanyEntities db = new Company_DAL.CompanyEntities();
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}