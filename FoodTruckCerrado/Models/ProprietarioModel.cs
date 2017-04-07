using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.Models
{
    public class ProprietarioModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Cpf { get; set; }

        public string Sexo { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        public string ConfimarSenha { get; set; }
    }
}