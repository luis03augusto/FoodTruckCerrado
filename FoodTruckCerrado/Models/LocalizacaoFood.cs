using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodTruckCerrado.Models
{
    public class LocalizacaoFood : Localizacao
    {
        public virtual int FoodTruckId { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime DataLocalização { get; set; }

        public virtual FoodTruck FoodTruck { get; set; }
    }
}