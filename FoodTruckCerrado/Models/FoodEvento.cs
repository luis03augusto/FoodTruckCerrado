using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class FoodEvento
    {

        public int FoodTruckId { get; set; }
        public virtual FoodTruck FoodTruck { get; set; }
        public int EventoId { get; set; }
        public virtual Evento Evento { get; set; }
    }
}