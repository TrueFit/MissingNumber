using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MissingNumber.Models;

namespace MissingNumber.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult MissingNumbersCheck()
        {
            if (Request.Files == null || Request.Files.Count == 0)
            {
                return Json("NoFile");
            }
            else
            { 
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
                if (extension != ".csv" && extension != ".txt")
                {
                    return Json("BadFileExtension");
                }

                var results = new MissingNumbersResults().getMissingNumbersFromFile(Request.Files[0]);

                if (results.Input.Count == 0)
                {
                    return Json("BadData");
                }
                else
                {
                    return Json(results);
                }
            }
        }
    }
}