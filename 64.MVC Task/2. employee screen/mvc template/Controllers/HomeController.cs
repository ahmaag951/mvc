using System.IO;
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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEmployees()
        {
            var empList = _EmployeeProxy.Items.Where(r => r.isDeleted != true);
            return PartialView("_Index", empList);
        }

        public void Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                _EmployeeProxy.Add(emp);
            }
        }

        public ActionResult ShowEdit(int? id)
        {
            var emp = (id == null ? new Emp() : _EmployeeProxy.GetById(id.Value));
            return PartialView("_Edit", emp);
        }

        public ActionResult Edit(Emp emp)
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

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                // Extract only the file name
                var fileName = Path.GetFileName(file.FileName);
                // if you want to store that file on the server (in the solution's folder)
                var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                file.SaveAs(path);


            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeImage()
        {
            return View("_ChangeImage");
        }
    }
}
