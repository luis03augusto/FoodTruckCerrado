using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class EventoFoodController : Controller
    {
        // GET: EventoFood
        EventoFoodDao dao;
        public EventoFoodController()
        {
            dao = new EventoFoodDao();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscaEvento(int idFood)
        {
            using (var contexto = new Contexto())
            {
                var evento = contexto.Eventos.ToList();
                var eventoFood = contexto.FoodEventos.Where(e => e.FoodTruckId == idFood).ToList();               
                ViewBag.Food = idFood;
                ViewBag.Evento = eventoFood;
                return View(evento);
            }
        }

        public ActionResult AddFood(int idFood, int idEvento)
        {
            dao.AddEventoFood(idFood, idEvento);
            return RedirectToAction("BuscaEvento", new { idFood = idFood });
        }

        public ActionResult SairDoEvento(int idFood, int idEvento)
        {
            using (var contexto = new Contexto())
            {
                var eventoFood = contexto.FoodEventos.FirstOrDefault(e => e.FoodTruckId == idFood && e.EventoId == idEvento);
                contexto.FoodEventos.Remove(eventoFood);
                contexto.SaveChanges();
            }
            return RedirectToAction("BuscaEvento", new { idFood = idFood });
        }

        public ActionResult BuscarEvnetoPorFood(int idFood)
        {
            using (var contexto = new Contexto())
            {
                var query = from e in contexto.FoodEventos
                            orderby e.Evento.Data
                            where e.FoodTruckId == idFood
                            select new Evento
                            {
                                Id = e.Evento.Id,
                                Nome = e.Evento.Nome,
                                Data = e.Evento.Data,
                                FotoCapa = e.Evento.FotoCapa
                            };
                ViewBag.Food = idFood;
                int Id = dao.IdUser(idFood);
                ViewBag.Id = Id;
                if (query.Count() == 0)
                {
                    return RedirectToAction("FoodSemEvento", new { id = idFood });
                }
                return View(query.ToList());
            }
        }
        public ActionResult FoodSemEvento(int id )
        {
            int Id = dao.IdUser(id);
            ViewBag.Id = Id;
            ViewBag.Food = id; 
            return View();
        }
    }
}