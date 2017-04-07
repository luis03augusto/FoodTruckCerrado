using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{

    public class FoodTruck
    {

        public virtual int Id { get; set; }
        [Required]
        public virtual string Nome { get; set; }
        [Required]
        public virtual string Descricao { get; set; }
        [Required]
        public virtual string Categoria { get; set; }
        [Required]
        public virtual string FotoCapa { get; set; }

        public virtual string Cidade { get; set; }

        public virtual int ProprietarioId { get; set; }

        public virtual Proprietario Proprietario { get; set; }

        public virtual IList<Prato> Prato { get; set; }

        public virtual IList<FoodEvento> FoodEvento { get; set; }

        public virtual IList<LocalizacaoFood> LocalizacaoFood { get; set; }

        public virtual IList<FotosFood> FotosFood { get; set; }
        
    }
}