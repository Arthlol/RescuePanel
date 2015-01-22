using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {

            WebSecurity.Login("PresentationAdmin", "123456");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult OperatorLogin()
        {

            WebSecurity.Login("PresentationOperator", "123456");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserLogin()
        {

            WebSecurity.Login("PresentationUser", "123456");
            return RedirectToAction("Index", "Home");
        }

        
    }
}
