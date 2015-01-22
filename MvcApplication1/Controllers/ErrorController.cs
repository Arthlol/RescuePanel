using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult HttpError404(string error)
        {
            ViewBag.Description = error;
            return View();
        }
        public ActionResult General()
        {
            return View();
        }

        public ActionResult HttpError500()
        {
            return View();
        }

    }
}
