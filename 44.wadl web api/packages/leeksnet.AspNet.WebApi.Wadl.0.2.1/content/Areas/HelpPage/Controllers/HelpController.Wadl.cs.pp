using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using $rootnamespace$.Areas.HelpPage.ModelDescriptions;
using $rootnamespace$.Areas.HelpPage.Models;

namespace $rootnamespace$.Areas.HelpPage.Controllers
{
	public partial class HelpController
	{
        public ActionResult Wadl(string controllerDescriptor)
        {
            var apiDescriptions = Configuration.Services.GetApiExplorer().ApiDescriptions;
            var apisWithHelp = apiDescriptions.Select(api => Configuration.GetHelpPageApiModel(api.GetFriendlyId()));

            return View(apisWithHelp);
        }

	}
}