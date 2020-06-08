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
        FileStoreProxy _FileStoreProxy = new FileStoreProxy();
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            // also it will be in Request.Files[0]
            if (file != null && file.ContentLength > 0)
            {
                // convert file to array of bytes
                var content = new byte[file.ContentLength];
                file.InputStream.Read(content, 0, file.ContentLength);
                
                _FileStoreProxy.Add(new FileStore { FileData = content });
                // Please note that FileData filed in the database is [varbinary(MAX)]
            }

            return RedirectToAction("Index");
        }

        public ActionResult Show() {
            var data = _FileStoreProxy.Items.LastOrDefault().FileData;
            return base.File(data, "image/jpg");
        }


    }
}
