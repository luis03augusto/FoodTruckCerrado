using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class PratoController : Controller
    {
        // GET: Prato
        PratoDao dao;
        public PratoController()
        {
            dao = new PratoDao();
        }

        public ActionResult NewPrato(int foodTruckId, int idUser)
        {
            Prato prato = new Prato { FoodTruckId = foodTruckId };
            ViewBag.Id = idUser;
            return View(prato);
        }

        public ActionResult Cardapio(int foodTruckId)
        {
            var prato = dao.BuscaProFood(foodTruckId);
            int id = dao.IdUser(foodTruckId);
            ViewBag.Id = id;
            if (prato.Count == 0)
            {
               
                return RedirectToAction("NewPrato", new {foodTruckId = foodTruckId, idUser = id });
            }
            else
            {
                return View(prato);
            }
        }
        public ActionResult Form(int foodTruckId)
        {
            Prato prato = new Prato { FoodTruckId = foodTruckId };
            return View(prato);
        }
        [HttpPost]
        public ActionResult Form(Prato prato, HttpPostedFileBase file)
        {
            dao.Adciona(prato, file);
            return RedirectToAction("Cardapio", new { foodTruckId = prato.FoodTruckId });
        }

        public ActionResult Deleta(int id)
        {
            Prato prato = dao.BuscaProId(id);
            dao.Deletar(prato);
            return RedirectToAction("Cardapio", new {foodTruckId = prato.FoodTruckId });
        }

        public ActionResult Atualizar(int id)
        {
            Prato prato = dao.BuscaProId(id);
            return View(prato);
        }
        [HttpPost]
        public ActionResult Atualizar(Prato prato, HttpPostedFileBase file)
        {
            dao.Atualizar(prato, file);
            return RedirectToAction("Cardapio", new { foodTruckId = prato.FoodTruckId });
        }

    }
}