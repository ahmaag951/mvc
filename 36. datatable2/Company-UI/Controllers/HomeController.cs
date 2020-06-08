using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using System.Web;
using System.Web.Mvc;
using Company_BLL;
using Company_UI.Models;
using Company_UI.Filters;
using Company_UI.Helpers;
using System.Linq.Dynamic;
using Company_DAL;

namespace Company_UI.Controllers
{
    public class HomeController : Controller
    {
        Employee_Proxy _Employee_Proxy = new Employee_Proxy();
        CountyProxy _CountyProxy = new CountyProxy();

        public ActionResult Index()
        {

            return View();

        }

        // Get Employee List
        public JsonResult GetEmpList()
        {
            var empList = _Employee_Proxy.GetAllEmployees().ToList().Select(x => new
            {
                id = x.id,
                name = x.name,
                age = x.age,
                country = (x.Country == null ? "" : x.Country.Name),
                countryId = x.countryId,
                email = x.email,
                isDeleted = x.isDeleted

            });

            return Json(empList, JsonRequestBehavior.AllowGet);

        }

        // Get Countries
        public JsonResult GetCountriesList()
        {
            var countries = _CountyProxy.Items.Select(x => new
            {
                id = x.Id,
                name = x.Name
            });

            return Json(countries, JsonRequestBehavior.AllowGet);

        }

        // Get Employee
        public JsonResult GetEmpById(int id)
        {
            var emp = _Employee_Proxy.GetByIdJson(id);

            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        // Delete Employee
        public void DeleteEmp(int id)
        {
            var emp = _Employee_Proxy.GetById(id);
            emp.isDeleted = true;
            _Employee_Proxy.Update(emp);

        }

        // Edit Employee
        public ActionResult EditEmp(int id)
        {
            var emp = _Employee_Proxy.GetById(id);

            return View("Edit", emp);

        }

        // Edit post
        public void Edit(Employee emp)
        {
            _Employee_Proxy.Update(emp);

        }

        // Add Employee
        public void AddEmp(Employee emp)
        {
            _Employee_Proxy.Add(emp);
        }

    }
}