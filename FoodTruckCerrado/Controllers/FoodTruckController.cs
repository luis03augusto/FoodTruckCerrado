using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    
    public class FoodTruckController : Controller
    {

        FoodTruckDao dao = new FoodTruckDao();
        // GET: FoodTruck
        public ActionResult Index()
        {
            var fotos = dao.Lista();
            return View(fotos);
        }
        [Authorize]
        public ActionResult Form()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListarPorProp()
        {
            var food = dao.BuscarPorProprietario();
            return View(food);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Adiciona(FoodTruck foodTruck, HttpPostedFileBase file)
        {
           
                dao.SalvarFood(foodTruck, file);
                return RedirectToAction("Index", "FoodTruck");
            
        }
        [Authorize]
        public ActionResult Deleta(int id)
        {
            FoodTruck food = dao.BuscarPorId(id);
            dao.Remover(food);
            return RedirectToAction("Index");
        }
        public ActionResult Visualiza(int id)
        {

            var food = dao.BuscarPorId(id);
            ViewBag.Fotos = dao.buscarFotos(id);
            return View(food);
        }
        [Authorize]
        public ActionResult Atualizar(int id)
        {
            FoodTruck food = dao.BuscarPorId(id);
            return View(food);
        }
        [Authorize]
        [HttpPost, ActionName("Atualizar")]
        public ActionResult AtualizarPost(FoodTruck fooTruck, HttpPostedFileBase file)
        {
            dao.Atualizar(fooTruck, file);
            return RedirectToAction("Index");
        }
    }
}