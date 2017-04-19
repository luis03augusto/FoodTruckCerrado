using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class LocalizacaoEventoDao
    {
        public void SalvarLocaliza(LocalizacaoEvento loc)
        {
            using (var context = new Contexto())
            {
                context.LocalizacoesEventos.Add(loc);
                context.SaveChanges();
            }
        }

        public LocalizacaoEvento BuscarPorEventoId(int idEvento)
        {
            using (var context = new Contexto())
            {
                return context.LocalizacoesEventos.FirstOrDefault(l => l.EventoId == idEvento);
            }
        }
        public LocalizacaoEvento BuscarPorId(int idEvento)
        {
            using (var context = new Contexto())
            {
                return context.LocalizacoesEventos.FirstOrDefault(f => f.EventoId == idEvento);
            }
        }

        public void Deleta(LocalizacaoEvento locFood)
        {
            using (var context = new Contexto())
            {
                context.Remove(locFood);
                context.SaveChanges();
            }
        }
        public void Atualizar(LocalizacaoEvento locaEvento)
        {
            using (var context = new Contexto())
            {
                var orinal = context.LocalizacoesEventos.FirstOrDefault(f => f.EventoId == locaEvento.EventoId);
                if (orinal != null)
                {
                    orinal.Descricao = locaEvento.Descricao;
                    orinal.Latitude = locaEvento.Latitude;
                    orinal.Logitude = locaEvento.Logitude;
                    context.SaveChanges();
                }
            }
        }
    }
}