using RestClientDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var countryCodeClient = new RestClientDotNet.RestClient(new NewtonsoftSerializationAdapter(), new Uri("http://localhost:5675/api/values?id=5"));
            var countryData = countryCodeClient.GetAsync<string>();

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
