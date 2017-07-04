using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBook.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        [Display(Name = "Nome")]
        public string NomeCategoria { get; set; }
        public bool Ativo { get; set; }
    }
}