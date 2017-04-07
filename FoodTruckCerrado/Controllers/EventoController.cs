using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        EventoDao dao;
        public EventoController()
        {
            dao = new EventoDao();
        }

        public ActionResult Index()
        {
            var eventos = dao.ListarTodos();
            if (eventos != null)
            {
                return View(eventos);
            }
            else
            {
                return RedirectToAction("SemEvento");
            }
        }

        public ActionResult Visualiza(int id)
        {
            using (var contexto = new Contexto())
            {
                var query = from e in contexto.FoodEventos
                            where e.EventoId == id
                            select new FoodTruck
                            {
                                Id = e.FoodTruck.Id,
                                Nome = e.FoodTruck.Nome,
                                FotoCapa = e.FoodTruck.FotoCapa
                            };
                ViewBag.loca = contexto.LocalizacoesEventos.FirstOrDefault(l => l.EventoId == id);
                ViewBag.evento = contexto.Eventos.FirstOrDefault(e => e.Id == id);
                return View(query.ToList());
            }
        }
        public ActionResult Atualizar(int id)
        {
            var evento = dao.BuscarPorId(id);
            return View(evento);
        }

        [HttpPost]
        public ActionResult Atualizar(Evento evento, HttpPostedFileBase file)
        {
            dao.Atualizar(evento, file);
            return RedirectToAction("Visualiza", new { id = evento.Id });
        }
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(Evento evento, HttpPostedFileBase file)
        {  
                dao.Adicionar(evento, file);
                return RedirectToAction("Index");
        }
        public ActionResult SemEvento()
        {
            return View();
        }

        public ActionResult Deleta(int id)
        {
            var evento = dao.BuscarPorId(id);
            dao.Deletar(evento);
            return RedirectToAction("Index");
        }
    }
}