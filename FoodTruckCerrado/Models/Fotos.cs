using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public abstract class Fotos
    {
        public virtual int Id { get; set; }

        public virtual string Url { get; set; }


    }
}