using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class LocalizacaoFoodController : Controller
    {
        // GET: LocalizacaoFood
        LocalizaFoodDao dao;

        public LocalizacaoFoodController()
        {
            dao = new LocalizaFoodDao();
        }
                     
        public ActionResult Index(int id, int idUser)
        {
            var  loca = dao.BuscarPorId(id);
            ViewBag.Id = idUser;
            return View(loca);
        }

        public ActionResult Form(int idFood)
        {
            var localiza = new LocalizacaoFood
            {
                FoodTruckId = idFood
            };
            return View(localiza);
        }
        [HttpPost]
        public ActionResult Form(LocalizacaoFood loc)
        {
            dao.SalvarLocaliza(loc);
            return RedirectToAction("BuscaLoc", new {idFood = loc.FoodTruckId }); 
        }

        public ActionResult Deleta(int id)
        {
            var loc = dao.BuscarPorId(id);
            dao.Deleta(loc);
            return RedirectToAction("BuscaLoc", new { idFood = loc.FoodTruckId });
        }

        public ActionResult BuscaLoc(int idFood)
        {
            int Id = dao.IdUser(idFood);
            ViewBag.Id = Id;
            var loc = dao.ListarTodo(idFood);
            if (loc.Count() != 0)
            {
                return View(loc);
            }
            else
            { 
                return RedirectToAction("SemLoc",new { idFood = idFood, idUser = Id});
            }
        }
        public ActionResult Historico(int idFood)
        {
            int Id = dao.IdUser(idFood);
            ViewBag.Id = Id;
            var historico = dao.BuscarHitorico(idFood);
            return View(historico);
        }

        public ActionResult SemLoc(int idFood, int idUser)
        {
            LocalizacaoFood loc = new LocalizacaoFood
            {
                FoodTruckId = idFood
            };
            ViewBag.Id = idFood;
            return View(loc);
        }
        
        public ActionResult Atualiza(int id)
        {
            var locFood = dao.BuscarPorId(id);
            return View(locFood);
        } 
        [HttpPost]
        public ActionResult Atualiza(LocalizacaoFood loc)
        {
            dao.Atualizar(loc);
            return RedirectToAction("BuscaLoc", new { idFood = loc.FoodTruckId });
        }
    }
}