using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class LocalizaFoodDao
    {
        public void SalvarLocaliza(LocalizacaoFood loc)
        {
            using(var context = new Contexto())
            {
                context.LocalizacoesFood.Add(loc);
                context.SaveChanges();
            }
        }

        public LocalizacaoFood BuscarPorFoodTruckId(int id)
        {
            using(var context = new Contexto())
            {
                return context.LocalizacoesFood.FirstOrDefault(l => l.FoodTruckId == id);
            }
        }

        public IList<LocalizacaoFood> ListarTodo(int id)
        {
            using (var context = new Contexto())
            {
                return context.LocalizacoesFood.Where(l => l.FoodTruckId == id && l.DataLocalização > DateTime.Now).OrderBy(l => l.DataLocalização).ToList();
                
            }
        }

        public LocalizacaoFood BuscarPorId(int id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.LocalizacoesFood.FirstOrDefault(l => l.Id == id);
            }
        }

        public void Deleta(LocalizacaoFood locFood)
        {
            using (var context = new Contexto())
            {
                context.Remove(locFood);
                context.SaveChanges();
            }
        }

        public void Atualizar(LocalizacaoFood locFood)
        {
            using (var context = new Contexto())
            {
                var orinal = context.LocalizacoesFood.FirstOrDefault(f => f.Id == locFood.Id);
                if (orinal != null)
                {
                    orinal.Descricao = locFood.Descricao;
                    orinal.Latitude = locFood.Latitude;
                    orinal.Logitude = locFood.Logitude;
                    orinal.DataLocalização = locFood.DataLocalização;
                    context.SaveChanges();
                }
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