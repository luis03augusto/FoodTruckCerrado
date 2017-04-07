using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace FoodTruckCerrado.Controllers
{
    public class ProprietarioController : Controller
    {
        // GET: Proprietario
        ProprietarioDao dao;
        public ProprietarioController()
        {
            dao = new ProprietarioDao();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(ProprietarioModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //passar para DAO
                    string roleName = "user";
                    var role = (SimpleRoleProvider)Roles.Provider;

                    WebSecurity.CreateUserAndAccount(model.Email, model.Senha,
                        new { Nome = model.Nome, Sobrenome = model.Sobrenome, Cpf = model.Cpf, Sexo = model.Sexo });
                    role.AddUsersToRoles(new[] { model.Email }, new[] { roleName });
                    return View("Index", "Home");

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Usuario.Invalido", e.Message);
                    return View("Form", model);
                }
            }
            else
            {
                return View("Form", model);
            }
        }

        public ActionResult ListaTodos()
        {
            var user = dao.ListaTodos();
            return View(user);
        }

        public ActionResult DeltarUser(string email)
        {
            dao.DeletaUser(email);
            return RedirectToAction("ListaTodos");
        }

    }
}