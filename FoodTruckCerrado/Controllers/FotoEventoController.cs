using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class FotoEventoController : Controller
    {
        FotoEventoDao dao;
        public FotoEventoController()
        {
            dao = new FotoEventoDao();
        }
        // GET: FotoEvento
        public ActionResult Index( int idEvento)
        {
            var fotos = dao.Listar(idEvento);
            if (fotos.Count == 0)
            {
                return RedirectToAction("SemFotos", new { id = idEvento });
            }
            else
            {
                return View(fotos);
            }
            
        }
        public ActionResult SemFotos(int id)
        {
            var fotos = new FotosEventos
            {
                EventoId = id
            };
            return View(fotos);
        }

        public ActionResult Form(int idEvento)
        {
            var fotos = new FotosEventos
            {
                EventoId = idEvento
            };
            return View(fotos);
        }
        [HttpPost]
        public ActionResult Form(FotosEventos fotos, HttpPostedFileBase file)
        {
            if (file != null)
            {
                dao.AddFoto(fotos, file);
                return RedirectToAction("Index", new { idEvento = fotos.EventoId });
            }
            else
            {
                return RedirectToAction("Index", new { idEvento = fotos.EventoId });
            }
        }
        public ActionResult Deleta(int Id)
        {
            var fotos = dao.BuscarPorId(Id);
            dao.Deleta(fotos);
            return RedirectToAction("Index", new { idEvento = fotos.EventoId });
        }
    }
}