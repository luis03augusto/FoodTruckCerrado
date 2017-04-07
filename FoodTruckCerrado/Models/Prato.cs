using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class Prato
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Descricao { get; set; }

        public virtual double Preco { get; set; }

        public virtual string FotoPrato { get; set; }

        public virtual int FoodTruckId { get; set; }

        public virtual FoodTruck FoodTruck { get; set; }
    }
}