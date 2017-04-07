using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace FoodTruckCerrado.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            if (WebSecurity.Login(login, senha))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha inválido");
                return View("Index");
            }
           
        }
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
    }
}