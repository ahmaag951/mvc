using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc_template.Controllers
{
    public class FilesController : Controller
    {
        public void uploadCK(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/UploadedImages"), ImageName);
                upload.SaveAs(path);
            }
        }

        public ActionResult CKEditorFiles()
        {
            var appData = Server.MapPath("~/Content/UploadedImages");
            var images = Directory.GetFiles(appData).Select(x => new imagesviewmodel
            {
                Url = Url.Content("/Content/UploadedImages/" + Path.GetFileName(x))
            });
            return View(images);
        }
    }

    public class imagesviewmodel
    {
        public string Url { get; set; }
    }
    //public class imagesviewmodel
    //{
    //    public string Url { get; set; }
    //}
   
}