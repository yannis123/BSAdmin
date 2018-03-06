using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace web.Controllers
{
    public class SystemSetController : Controller
    {
        // GET: SystemSet
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Upload()
        {
            //Request.Files[0]

            var file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                var fileNameLength = file.FileName.Split('.').Length;
                var fileName = "index" + "." + file.FileName.Split('.')[fileNameLength - 1];
                try
                {
                    var path = AppDomain.CurrentDomain.BaseDirectory + "uploadFiles";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    file.SaveAs(path + "\\" + fileName);
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);
        }
    }
}