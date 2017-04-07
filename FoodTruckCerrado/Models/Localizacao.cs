using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public abstract class Localizacao
    {

        public  int Id { get; set; }

        public  string Latitude { get; set; }

        public  string Logitude { get; set; }

        public  string Descricao { get; set; }


    }
}