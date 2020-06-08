using BusinessLogic;
using DataAccess;
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
        CountryProxy _CountryProxy = new CountryProxy();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult GetEmployees()
        {
            var empList = _EmployeeProxy.Items.Where(r => r.isDeleted != true);
            // I don't see any diffrences between 
            // return View("_Index", empList); and 
            return PartialView("_Index", empList);
        }

        public void Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _EmployeeProxy.Add(emp);
            }
        }

        public ActionResult ShowEdit(int? id)
        {
            var emp = (id == null ? new Employee() : _EmployeeProxy.GetById(id.Value));
            ViewBag.Countires = _CountryProxy.Items.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
            });
            return PartialView("_Edit", emp);
        }

        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _EmployeeProxy.Update(emp);
            }

            return RedirectToAction("GetEmployees");
        }

        public void Delete(int id)
        {
            var emp = _EmployeeProxy.GetById(id);
            if (emp != null)
            {
                emp.isDeleted = true;
                _EmployeeProxy.Update(emp);
            }
        }
    }
}
