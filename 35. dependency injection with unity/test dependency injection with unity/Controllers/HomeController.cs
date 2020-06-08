//using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace test_dependency_injection_with_unity.Controllers
{
    public class HomeController : Controller
    {
        private IGreetingService _greetingService;
        //private IEmployeeService _service;

        public HomeController(IGreetingService greetingService)//, IEmployeeService service)
        {
            _greetingService = greetingService;
           // _service = service;
        }

        public string Index()
        {
            //var list = _service.GetAll();
            return _greetingService.SayHello();
        }

    }
}
