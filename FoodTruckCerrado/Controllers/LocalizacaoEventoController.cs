using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class LocalizacaoEventoController : Controller
    {
        LocalizacaoEventoDao dao;

        public LocalizacaoEventoController()
        {
            dao = new LocalizacaoEventoDao();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(int idEvento)
        {
            var localiza = new LocalizacaoEvento
            {
                EventoId = idEvento
            };
            return View(localiza);
        }
        [HttpPost]
        public ActionResult Form(LocalizacaoEvento loc)
        {
            dao.SalvarLocaliza(loc);
            return RedirectToAction("Visualiza", "Evento", new { id = loc.EventoId });
        }

        public ActionResult Deleta(int idEvento)
        {
            var loc = dao.BuscarPorId(idEvento);
            dao.Deleta(loc);
            return RedirectToAction("Visualiza", "Evento", new { id = loc.EventoId });
        }

        public ActionResult BuscaLoc(int idEvento)
        {
            LocalizacaoEvento loc = dao.BuscarPorEventoId(idEvento);
            if (loc != null)
            {
                ViewBag.Loc = loc;
                return View("Index");
            }
            else
            {
                return RedirectToAction("SemLoc", new { id = idEvento });
            }
        }

        public ActionResult SemLoc(int idEvento)
        {
            var loc = new LocalizacaoEvento
            {
                EventoId = idEvento
            };
            return View(loc);
        }

        public ActionResult Atualiza(int idEvento)
        {
            var locFood = dao.BuscarPorId(idEvento);
            return View(locFood);
        }
        [HttpPost]
        public ActionResult Atualiza(LocalizacaoEvento locFood)
        {
            dao.Atualizar(locFood);
            return RedirectToAction("Visualiza", "Evento", new {id = locFood.EventoId });
        }
    }
}