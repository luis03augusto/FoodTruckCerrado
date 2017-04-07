using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class EventoFoodDao
    {
        public void AddEventoFood(int IdFood, int IdEvento)
        {
            using (var contexto = new Contexto())
            {
                if (IdFood != 0 && IdEvento != 0)
                {
                    var food = contexto.FoodTrucks.FirstOrDefault(f => f.Id == IdFood);
                    var evento = contexto.Eventos.FirstOrDefault(e => e.Id == IdEvento);
                    var eventoFood = new FoodEvento()
                    {
                        FoodTruck = food,
                        Evento = evento
                    };
                    contexto.FoodEventos.Add(eventoFood);
                    contexto.SaveChanges();
                }
            }
        }

        public IList<FoodEvento> BuscarFood(int idEvento)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FoodEventos.Where(f => f.EventoId == idEvento).ToList();
            }
        }

        public IList<FoodEvento> BuscarEvento(int idFood)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FoodEventos.Where(f => f.FoodTruckId == idFood).OrderBy(e => e.Evento.Data).ToList();
            }
        }

        public int IdUser(int id)
        {
            using (var contexto = new Contexto())
            {
                var query = contexto.FoodTrucks.FirstOrDefault(f => f.Id == id);

                if (query != null)
                {
                    int ID = Convert.ToInt32(query.ProprietarioId);
                    return ID;
                }
                return 0;
            }
        }
    }
}