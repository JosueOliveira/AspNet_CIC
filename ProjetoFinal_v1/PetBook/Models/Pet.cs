using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetBook.Models
{
    public class Pet
    {
        public int PetID { get; set; } 
        [Display(Name = "Nome do Pet")]        
        public string NomePet { get; set; }
        [Display(Name = "Idade do Pet")]
        public int IdadePet { get; set; }
        [Display(Name = "Proprietário")] 
        public string DonoPet { get; set; }
        public bool Ativo { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaID { get; set; }
        public virtual Categoria _Categoria { get; set; }



    }
}