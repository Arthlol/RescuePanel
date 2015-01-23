using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcApplication1.Controllers
{
    // Отвечает за главную страницу и тестовые данные
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
        // Тестовые методы для быстрой авторизации.
        // Как администратор
        public ActionResult AdminLogin()
        {

            WebSecurity.Login("PresentationAdmin", "123456");
            return RedirectToAction("Index", "Home");
        }
        // Как оператор
        public ActionResult OperatorLogin()
        {

            WebSecurity.Login("PresentationOperator", "123456");
            return RedirectToAction("Index", "Home");
        }
        // Как обычный пользователь
        public ActionResult UserLogin()
        {

            WebSecurity.Login("PresentationUser", "123456");
            return RedirectToAction("Index", "Home");
        }

        
    }
}
