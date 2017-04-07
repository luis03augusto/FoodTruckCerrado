using System.Collections.Generic;

namespace FoodTruckCerrado.Models
{
    public class FotosFood :Fotos
    {
        public virtual int FoodTruckId { get; set; }

        public virtual FoodTruck FoodTruck { get; set; }
    }
}