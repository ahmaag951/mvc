using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class HomeController : Controller
    {
        MyCompanyContext _context = new MyCompanyContext();
        // 1. PCM: > Install-Package EntityFramework
        // 2. Database context and the related entity objects (Emp, Dept)
        // 3. here, and EF will create database and every thing for you
        // if you want to see the created database 
        // click view => server explorer => data connections => add
        // server name => (localdb)\v11.0 and you will see your database select it
        
        // now if you updated the model like adding new property(address for example) to employees 
        // and try to run the application an InvalidOperationException will happen and the error message will be like this
        // "The model backing the 'MyCompanyContext' context has changed since the database was created. 
        // Consider using Code First Migrations to update the database"
        // 4. for the migrations
        // A.Enable-Migrations : this will create migrations folder with configuration.cs and _initialCreate.cs in it
        // B.Add-Migration AddAddress(this is just a name we call it that because we added the address property)
        // C.Update-Database 
        // now it will run okay
        // if you want to know more details about the sql statement that is executed while Update-Database is running
        // you can write 'Update-Database -Verbose

        public ActionResult Index()
        {
            var emp = new Employee { Name = "sayed", Address="cairo" };
            _context.Employees.Add(emp);
            _context.SaveChanges();

            var list = _context.Employees.ToList();
            return View();
        }

    }
}
