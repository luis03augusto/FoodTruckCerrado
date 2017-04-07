using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class Evento
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public virtual DateTime Data { get; set; }

        public virtual string FotoCapa { get; set; }

        public virtual string Descricao { get; set; }

        public virtual string Cidade { get; set; }

        public virtual LocalizacaoEvento LocalizacaoEvento { get; set; }

        public virtual IList<FoodEvento> FoodEvento { get; set; }
        
    }
}