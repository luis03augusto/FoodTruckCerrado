using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class Proprietario
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string Sobrenome { get; set; }

        public virtual string Cpf { get; set; }

        public virtual string Email { get; set; }

        public virtual string Sexo { get; set; }

        public virtual IList<FoodTruck> FoodTrucks { get; set; }


    }
}