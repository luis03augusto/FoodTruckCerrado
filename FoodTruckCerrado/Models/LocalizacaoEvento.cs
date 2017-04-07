using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class LocalizacaoEvento : Localizacao
    {
        public virtual int EventoId { get; set; }

        public virtual Evento Eventos { get; set; }
    }
}